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
        private Toy _nextToy;

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set
            {
                _factory = value;
                DisplayNext();
            }
        }

        private void DisplayNext()
        {
            if (_nextToy != null) Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = lbl_comingNext.Top + lbl_comingNext.Height + 8;
            _nextToy.Left = lbl_comingNext.Left;
            Controls.Add(_nextToy);
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

        private void btn_car_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void btn_ball_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory
            {
                BallColor = btn_color_ball_1.BackColor
            };
        }  

        private void btn_present_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory
            {
                BoxColor = btn_color_present_1.BackColor,
                RibbonColor=btn_color_present_2.BackColor
            };
        }
        private void btn_color(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var chosenColor = new ColorDialog();
            chosenColor.Color = button.BackColor;
            if (chosenColor.ShowDialog() != DialogResult.OK) return;
            button.BackColor = chosenColor.Color;
        }
    }
}

