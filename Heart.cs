using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class Heart : FallingObject
    {
        public Heart(Window window)
        {
            Name = "heart";
            Radius = 22;
            X = SplashKit.Rnd(window.Width - 2 * Radius) + Radius;
            Y = 0;
            Image = new Bitmap("heart", "C:\\Desktop\\OOP\\CustomProgram\\image\\heart.png");
            Health = 1;

        }
        public override void Move()
        {
            Y += 0.12;
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X - Radius, Y - Radius);
        }
    }
}
