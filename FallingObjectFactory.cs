using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class FallingObjectFactory
    {
        public FallingObject Create (int ID, Window window)
        {
            if (ID == 1)
            {
                return new Heart(window);
            }
            if (ID == 2)
            {
                return new Minion(window);
            }
            if (ID == 3)
            {
                return new Boss(window);
            }
            if (ID == 4)
            {
                return new Ability (window);
            }
            return null;
        }
    }
}
