using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class Boss : FallingObject
    {
        
      
        public Boss(Window window)
        {
            Name = "boss";
            X = SplashKit.Rnd(window.Width - 2 * Radius) + Radius;
            Y = 0;
            Image = new Bitmap("boss", "C:\\Desktop\\OOP\\CustomProgram\\image\\boss.png");
            Radius = 69;
            Health = 12;

        }
        public override void Move()
        {
            Y += 0.01;
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X - Radius, Y - Radius );
        }
    }
}
