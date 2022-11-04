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

        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
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
    }
}
