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
        List<Ball> _balls = new List<Ball>();

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private BallFactory _factory;

        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _balls.Add(ball);
            mainPanel.Controls.Add(ball);
            ball.Left = -ball.Left;
        }
        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var mostRightBall = 0;
            foreach (var b in _balls)
            {
                b.MoveBall();
                if (b.Left > mostRightBall)
                    mostRightBall = b.Left;
            }

            if (mostRightBall >= 1000)
            {
                var toDelet = _balls[0];
                _balls.Remove(toDelet);
                mainPanel.Controls.Remove(toDelet);
            }
        }
    }
}
