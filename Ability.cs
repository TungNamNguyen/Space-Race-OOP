using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class Ability : FallingObject
    {
        public Ability(Window window)
        {
            Name = "ability";
            Radius = 24;
            X = SplashKit.Rnd(window.Width - 2 * Radius) + Radius;
            Y = 0;
            Image = new Bitmap("ability", "C:\\Desktop\\OOP\\CustomProgram\\image\\ability.png");
            Health = 1;

        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image,X - Radius, Y - Radius);
        }
        public override void Move()
        {
            Y += 0.12;
        }

    }
}
