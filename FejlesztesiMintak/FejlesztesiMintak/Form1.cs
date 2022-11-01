using FejlesztesiMintak.Abstractions;
using FejlesztesiMintak.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FejlesztesiMintak
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private IToyFactory _factory;

        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add(toy);
            mainPanel.Controls.Add(toy);
            toy.Left = -toy.Left;
        }
        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var mostRightItem = 0;
            foreach (var b in _toys)
            {
                b.MoveToy();
                if (b.Left > mostRightItem)
                    mostRightItem = b.Left;
            }

            if (mostRightItem >= 1000)
            {
                var toDelet = _toys[0];
                _toys.Remove(toDelet);
                mainPanel.Controls.Remove(toDelet);
            }
        }
    }
}
