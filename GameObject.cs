using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class GameObject
    {
        private double _x;
        private double _y;
        private int _radius;
        private Bitmap _image;
        private string _name;
        
        public double X
        { get { return _x; } set { _x = value; } }
        public double Y
        { get { return _y; } set { _y = value; } } 
        public int Radius
        { get { return _radius; } set { _radius = value; } }
        public Bitmap Image
        { get { return _image; } set { _image = value; } }
        public string Name
        { get { return _name; } set { _name = value; } }
        public GameObject() 
        {
         
        }
        public virtual void Draw()
        {

        }

        public virtual void Move()
        {

        }
    }
}
