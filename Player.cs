using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class Player : GameObject
    {
        
        private Window _window;
        private int _health;
        private Bitmap _healthimage;
        
       
        public Window Window
        { get { return _window; } set { _window = value; } }
      
        public int Health
        { get { return _health; } set { _health = value; } }

        
        public Player (Window window) 
        {
            Name = "player";
            X = 350;
            Y = 350;
            Image = new Bitmap("player", "C:\\Desktop\\OOP\\CustomProgram\\image\\player.png");
            Radius = 20;
            Window = window;
            Health = 10;
            _healthimage = new Bitmap("healthimage", "C:\\Desktop\\OOP\\CustomProgram\\image\\heart_7.png");
            
        }
        public void DrawPlayerHealthBar()
        {   
            var length = 100;
            double hplength = (Health / 10F) * length;
            SplashKit.FillRectangle(Color.Gray, 0, 0, 150, 100);
            SplashKit.DrawBitmap(_healthimage, 10, 30);
            SplashKit.DrawRectangle(Color.Black,30 , 30, length, 20);
            SplashKit.FillRectangle(Color.Red,30 ,30, hplength, 20);
        }
        

        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X - Radius, Y - Radius);
            DrawPlayerHealthBar();
        }
        public override void Move()
        {
            if (X > Window.Width - Radius)
            {
                X = Window.Width - Radius;
            }
            if (Y > Window.Height - Radius)
            {
                Y = Window.Height - Radius;
            }
            if (X < Radius)
            {
                X = Radius;
            }
           
        }
     
        
    

    }
    
}
