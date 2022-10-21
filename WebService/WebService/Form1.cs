using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using WebService.Entities;
using WebService.MnbServiceReference;

namespace WebService
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();

        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = Rates;

            RefreshData();
        }

        private void RefreshData()
        {
            Rates.Clear();

            CallWebservice();
            CreateChart();
        }

        private void CallWebservice()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = comboBox1.SelectedItem.ToString(),
                startDate = dateTimePicker1.Value.ToString(),
                endDate = dateTimePicker2.Value.ToString()
            };

            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;

            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rd = new RateData();
                Rates.Add(rd);

                rd.Date = DateTime.Parse(element.GetAttribute("date"));
                
                var firstChild = (XmlElement)element.ChildNodes[0];
                rd.Currency = firstChild.GetAttribute("curr");

                var unit = decimal.Parse(firstChild.GetAttribute("unit"));
                var value = decimal.Parse(firstChild.InnerText);
                if (unit != 0)
                {
                    rd.Value = value/unit;
                }
            }
        }

        private void CreateChart()
        {
            chart1.DataSource = Rates;
            var series = chart1.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var area = chart1.ChartAreas[0];
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisY.IsStartedFromZero = false;

            var legend = chart1.Legends[0];
            legend.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
