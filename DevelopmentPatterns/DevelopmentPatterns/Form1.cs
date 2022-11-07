using DevelopmentPatterns.Abstractions;
using DevelopmentPatterns.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevelopmentPatterns
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();

        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value;
                DisplayNext();
            }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Toy t = Factory.CreateNew();
            _toys.Add(t);
            mainPanel.Controls.Add(t);
            t.Left = -t.Width;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;

            foreach (var t in _toys)
            {
                t.MoveToy();

                if (t.Left > maxPosition) { maxPosition = t.Left; }
            }

            if (maxPosition > 1000)
            {
                var oldestBall = _toys[0];
                _toys.Remove(oldestBall);
                mainPanel.Controls.Remove(oldestBall);
            }
        }

        private Toy _nextToy;

        private void btnCar_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void btnBall_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory()
            {
                BallColor = btnBallColor.BackColor
            };
        }
        private void btnPresent_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory()
            {
                BoxColor = btnBoxColor.BackColor,
                RibbonColor = btnRibColor.BackColor
            };
        }

        private void DisplayNext()
        {
            if (_nextToy != null) { Controls.Remove(_nextToy); };
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + 20;
            _nextToy.Left = label1.Left+20;
            Controls.Add(_nextToy);
        }

        private void btnBallColor_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPicker = new ColorDialog();
            colorPicker.Color = button.BackColor;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;
            button.BackColor = colorPicker.Color;
        }
    }
}
