using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class Explosion : GameObject
    {
        private Window _window;
        private bool _isfinished;
      //  private Timer _timer;
  
        
        public Explosion(Window window, double x,double y)
        {
            Name = "explosion";
            X = x;
            Y = y;
            Radius = 30;
            Image = SplashKit.LoadBitmap("explosion", "C:\\Desktop\\OOP\\CustomProgram\\image\\explosion2.png");
            _window = window;
            _isfinished = false;
        }
        public bool IsFinished
        {
            get { return _isfinished; }
            set { _isfinished = value; }
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X - Radius , Y - Radius);  
        }
        public override void Move()
        {

        }
    }
}
