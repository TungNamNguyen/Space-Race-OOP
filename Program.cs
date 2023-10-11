using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class Program
    {
      
        public static void Main()
        {
           Window window = new Window("Soace Race", 800, 640);
           SpaceRace game = new SpaceRace(window);
         
   
           do {
                SplashKit.ProcessEvents(); 
                SplashKit.ClearScreen();
                game.HandleInput(window);
                game.Draw(window);
                game.Update(window);
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
    
        }
    }
}
