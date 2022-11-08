using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VAR.Entities;

namespace VAR
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> ticks;
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();
        public Form1()
        {
            InitializeComponent();

            ticks = context.Ticks.ToList();
            dgvTick.DataSource = ticks;
            CreatePortfolio();
        }

        private void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() 
            { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() 
            { Index = "MOL", Volume = 10 });
            Portfolio.Add(new PortfolioItem() 
            { Index = "PICK", Volume = 10 });

            dvgPortfolio.DataSource = "";
        }
    }
}
