using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class Bullet : GameObject
    {

        private Window _window;
    
        public Bullet(Window window, double x, double y )
        {
            Name = "bullet";
            X = x;
            Y = y;
            Image = new Bitmap("bullet", "C:\\Desktop\\OOP\\CustomProgram\\image\\new_bullet.png");
            Radius = 12;
            _window = window;
         
                
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X - Radius, Y - Radius);
        }
        public override void Move()
        {
            Y -= 0.4;
        }
       public bool Onscreen()
       {
            int right = _window.Width + Radius;
            int left = - Radius;
            int top = - Radius;
            int bottom = _window.Height + Radius;
            if (X > left && X < right && Y > top && Y < bottom)
            {
                return true;
            }
            else return false;
                    
        }
    }
}
