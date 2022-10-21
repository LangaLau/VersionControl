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
using Webszolgaltatasok.Entities;
using Webszolgaltatasok.MnbServiceReference;

namespace Webszolgaltatasok
{
    public partial class Form1 : Form
    {
        BindingList<RateData> rates = new BindingList<RateData>();
        BindingList<string> currencies = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();

            cbBoxCurrency.DataSource = currencies;
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            GetCurrenciesRequestBody request = new GetCurrenciesRequestBody();
            var response= mnbService.GetCurrencies(request);
            string result = response.GetCurrenciesResult;
            XmlDocument xmlV = new XmlDocument();
            xmlV.LoadXml(result);
            foreach (XmlElement item in xmlV.DocumentElement.FirstChild.ChildNodes)
            {
                currencies.Add(item.InnerText);
            }

            RefreshData();
        }

        private void RefreshData()
        {
            if (cbBoxCurrency == null) return;
            rates.Clear();
            string xmlstring = GetWebService();
            LoadXML(xmlstring);
            Charting();
            dgwRates.DataSource = rates;
        }

        private string GetWebService()
        {
                      var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = cbBoxCurrency.SelectedItem.ToString(),
                startDate = dtpStart.Value.ToString("yyyy-mm-dd"), //"2022-01-01",
                endDate = dtpEnd.Value.ToString("yyyy-mm-dd")
            };

            var responose = mnbService.GetExchangeRates(request);
            string result = responose.GetExchangeRatesResult;
            return result;
        }

        private void LoadXML(string input)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(input);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                rates.Add(rate);

                // Dátum
                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                // Valuta
                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                // Érték
                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }
        private void Charting()
        {
            chartRateDate.DataSource = rates;
            Series series = chartRateDate.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;
            var chartArea = chartRateDate.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisX.IsStartedFromZero = false;
            var legend = chartRateDate.Legends[0];
            legend.Enabled = false;
        }


        private void Refresh(object sender, EventArgs e)
        {
            RefreshData();
        }

    }
}
