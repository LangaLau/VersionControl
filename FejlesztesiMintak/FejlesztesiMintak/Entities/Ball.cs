using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FejlesztesiMintak.Entities
{
    class Ball : Label
    {
        public Ball()
        {
            AutoSize = false;
            Width = Height = 50;
            Paint += Ball_Paint;

        }
        protected void DrawImage(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }
        public void MoveBall()
        {
            Left++;
        }
    }
}

