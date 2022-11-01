using FejlesztesiMintak.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FejlesztesiMintak.Entities
{
    public class Car : Toy
    {
        protected override void DrawImage(Graphics graphics)
        {
            Image imageFilePath = Image.FromFile("Images/car.png");
            graphics.DrawImage(imageFilePath, new Rectangle(0, 0, Width, Height));
        }
    }
}
