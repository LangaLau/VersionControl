using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Webszolgaltatasok.Entities;
using Webszolgaltatasok.MnbServiceReference;

namespace Webszolgaltatasok
{
    public partial class Form1 : Form
    {
        BindingList<RateData> rates = new BindingList<RateData>();
        public Form1()
        {
            InitializeComponent();

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
                currencyNames = "EUR",
                startDate = "2022-01-01",
                endDate = "2020-06-30"
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

        }
    }
}
