using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            GetWebService();
        }

        private void GetWebService()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2022-01-01",
                endDate = "2020-06-30"
            };

            var responose = mnbService.GetExchangeRates(request);
            string result = responose.GetExchangeRatesResult;
        }
    }
}
