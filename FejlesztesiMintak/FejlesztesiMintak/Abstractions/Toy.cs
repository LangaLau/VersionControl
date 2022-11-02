using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FejlesztesiMintak.Abstractions
{
    public abstract class Toy : Label
    {
        public Toy()
        {
            AutoSize = false;
            Width = Height = 70;
            Paint += Toy_Paint;
        }
        protected abstract void DrawImage(Graphics graphics);       

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }
        public virtual void MoveToy()
        {
            Left++;
        }
    }
}
