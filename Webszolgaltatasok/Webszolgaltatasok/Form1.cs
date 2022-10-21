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

            foreach (XmlElement item in xml.DocumentElement)
            {

                RateData r = new RateData();
                r.Date = DateTime.Parse(item.GetAttribute("date"));
                XmlElement child = (XmlElement)item.FirstChild;
                r.Currency = item.GetAttribute("curr");
                r.Value = decimal.Parse(child.InnerText);
                int unit = int.Parse(child.GetAttribute("unit"));
                if (unit != 0) r.Value = r.Value / unit;

                rates.Add(r);
            }
        }
        private void Charting()
        {
        }
    }
}
