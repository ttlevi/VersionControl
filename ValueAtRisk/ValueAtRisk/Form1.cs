using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueAtRisk.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ValueAtRisk
{
    public partial class Form1 : Form
    {
        List<Tick> ticks;
        PortfolioEntities context = new PortfolioEntities();
        List<PortfolioItem> portfolio = new List<PortfolioItem>();
        List<decimal> nyereségekRendezve;

        public Form1()
        {
            InitializeComponent();

            ticks = context.Ticks.ToList();
            dataGridView1.DataSource = ticks;
            CreatePortfolio();
            CreateNyereségek();
        }

        private void CreateNyereségek()
        {
            List<decimal> nyereségek = new List<decimal>();
            int intervalum = 30;
            DateTime kezdőDátum = (from x in ticks select x.TradingDay).Min();
            DateTime záróDátum = new DateTime(2016, 12, 30); // adott végdátum (lehetne a .Max() is, csak itt eddig használható az adatbázis
            TimeSpan z = záróDátum - kezdőDátum;
            for (int i = 0; i < z.Days - intervalum; i++) // az utolsó megnézendő kezdő nap a vége előtt egy "intervalumnyival" van
            {
                decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum)) // a nyereség/veszteség az intervalum vége...
                           - GetPortfolioValue(kezdőDátum.AddDays(i));             // ... és eleje közti különbség
                nyereségek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            nyereségekRendezve = (from x in nyereségek
                                      orderby x
                                      select x)
                                        .ToList();
            MessageBox.Show(nyereségekRendezve[nyereségekRendezve.Count() / 5].ToString()); // 5-tel osztva, mert 20% a kockázat
        }

        private void CreatePortfolio()
        {
            portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = portfolio;
        }

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in portfolio)
            {
                var last = (from x in ticks
                            where item.Index == x.Index.Trim()
                               && date <= x.TradingDay
                            select x)
                            .First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return;
            StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Default);
            sw.WriteLine("Időszak;Nyereség");
            int i = 1;
            foreach (var ny in nyereségekRendezve)
            {
                sw.WriteLine(i.ToString()+";"+ny.ToString());
                i++;
            }
            sw.Close();
        }
    }
}
