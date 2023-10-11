using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class Ally : GameObject
    {
        public Ally(Window window)
        {
            Name = "ally";
            X = SplashKit.Rnd(window.Width - 2 * Radius) + Radius;
            Y = 620;
            Radius = 20;
            Image = new Bitmap("ally", "C:\\Desktop\\OOP\\CustomProgram\\image\\ally.png");
            
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X - Radius, Y - Radius);
        }
        public override void Move()
        {
            Y -= 0.18;
        }

    }
}
