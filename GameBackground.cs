using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class GameBackground : GameObject
    {
        public GameBackground()
        {
            Name = "gamebackground";
            Image = new Bitmap("gamebackgrund", "C:\\Desktop\\OOP\\CustomProgram\\image\\back.jpg");
            X = 0;
            Y = 0;
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X, Y); 
        }
        public override void Move()
        {
           
        }
    }
}
