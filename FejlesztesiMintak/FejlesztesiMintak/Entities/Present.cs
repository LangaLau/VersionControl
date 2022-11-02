using FejlesztesiMintak.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FejlesztesiMintak.Entities
{
    public class Present : Toy
    {
        public SolidBrush BoxColor { get; private set; }
        public SolidBrush RibbonColor { get; private set; }

        public Present(Color box, Color ribbon)
        {
            BoxColor = new SolidBrush(box);
            RibbonColor = new SolidBrush(ribbon);
        }

        int ribbonPixel = 70/5*2;
        protected override void DrawImage(Graphics graphics)
        {
            graphics.FillRectangle(BoxColor, 0, 0, Width, Height);

            graphics.FillRectangle(RibbonColor, ribbonPixel, 0, Width / 5, Height);
            graphics.FillRectangle(RibbonColor, 0, ribbonPixel, Width, Height / 5);
        }
    }
}
