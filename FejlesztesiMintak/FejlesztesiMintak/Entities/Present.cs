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
        protected override void DrawImage(Graphics graphics)
        {
            graphics.FillRectangle(BoxColor, 0, 0, Width, Height);
            graphics.FillEllipse(RibbonColor, 0, 0, Width, Height);
        }
    }
}
