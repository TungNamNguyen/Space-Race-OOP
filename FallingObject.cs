using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public abstract class FallingObject : GameObject
    {
        private int _healthpoint;
        public FallingObject()
        {

        }
        public abstract override void Draw();
        public abstract override void Move();
        public int Health
        {
            get { return _healthpoint; }
            set { _healthpoint = value; }
        }

    }
}
