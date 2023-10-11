using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class SpaceRace
    {
        private FallingObjectmanager _fallingobjectmanager;
        // Starting screen
        private Bitmap gamelogo;
        private Bitmap startbackground;
        private string startoption1;
        private string startoption2;

        //game
        private Player player;
        private GameBackground gamebackground;
        // Object List
        private List<Bullet> bulletlist;
        private List<Ally> allylist;
        private List<Explosion> explosionlist;
        // Remove Object List
        private List<Bullet> removebullet;
        private List<Ally> removeally;     
        private List<Explosion> removeexplosion;
        private List<FallingObject> removefallingobject;
        // TImer
        private Timer _timer;
        // scene
        private string _scene;
        // Result of the ending sceren
        private string endmessage1;
        private string endmessage2;
       
        public SpaceRace(Window window) // Initialize SpaceRace => Run the Intialize_Start ()
        {   
            Initialize_Start();
        }
        public void Initialize_Start()
        {
            _scene = "start";
            gamelogo = new Bitmap("gamelogo", "C:\\Desktop\\OOP\\CustomProgram\\image\\space_race_logo.png");
            startbackground = new Bitmap("startbackground", "C:\\Desktop\\OOP\\CustomProgram\\image\\background.png");
            startoption1 = "New Game (Press Q)";
            startoption2 = "Quit (Press W)";
        }
        public void Initialize_Game(Window window)
        {
            _fallingobjectmanager = new FallingObjectmanager();
            player = new Player(window);
            gamebackground = new GameBackground();
            // Create new object list 
            bulletlist = new List<Bullet>();
            allylist = new List<Ally>();
            explosionlist = new List<Explosion>();
            // Create new removed object list
            removebullet = new List<Bullet>();
            removeally = new List<Ally>();
            removeexplosion = new List<Explosion>();
            removefallingobject = new List<FallingObject>();
            _timer = new Timer("timer");
            _timer.Start();
            _scene = "game";

        }
        public void Initialize_End(string fate)
        {
            if (fate == "hit_by_enemy")
            {
                endmessage1 = "You were kiiled by an enemy";
            }
            else if (fate == "hit_by_boss")
            {
               endmessage1 = "You were smashed by a boss";
            }
            else if (fate == "off_border")
            {
                endmessage1 = "You moved out of the safe zone";
            }
            else if (fate == "boss_reach_base")
            {
               endmessage1 = "Boss reached the base";
            }
            else if (fate == "minion_reach_base")
            {
                endmessage1 = "An enemy reached the base";
            }
            endmessage2 = "Press E to play again, or R to return to the main menu";
            _scene = "end";
        }
        public bool CheckCollision(GameObject object1, GameObject object2)
        {
            return SplashKit.BitmapCollision(object1.Image, object1.X-object1.Radius, object1.Y-object1.Radius, object2.Image, object2.X-object2.Radius, object2.Y-object2.Radius);
        }
        
        // Handle Input
        public void HandleInputGame(Window window)
        {
            if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                player.X += 0.35;
            }
            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                player.X -= 0.35;
            }
            if (SplashKit.KeyDown(KeyCode.UpKey))
            {
                player.Y -= 0.35;
            }
            if (SplashKit.KeyDown(KeyCode.DownKey))
            {
                player.Y += 0.35;
            }
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                bulletlist.Add(new Bullet(window, player.X, player.Y));
            }
        }
        public void HandleInputStart(Window window)
        {
            if (SplashKit.KeyTyped(KeyCode.QKey))
            {
                Initialize_Game(window);
            }
            if (SplashKit.KeyTyped(KeyCode.WKey))
            {
                SplashKit.CloseCurrentWindow();
            }

        }
        public void HandleInputEnd(Window window)
        {
            if (SplashKit.KeyTyped(KeyCode.EKey))
            {
                Initialize_Game(window);
            }
            if (SplashKit.KeyTyped(KeyCode.RKey))
            {
                Initialize_Start();
            }
                
        }
        public void HandleInput(Window window)
        {
            if (_scene == "start")
            {
                HandleInputStart(window);
            }
            else if (_scene == "game")
            {
                HandleInputGame(window);
            }
            else if (_scene == "end")
            {
                HandleInputEnd(window);
            }
        }
        
       // Finishing the explosion 
        public void FinishingExplosion()
        {   foreach (Explosion explosion in explosionlist)
            {
                if (explosionlist.Count != 0 && (_timer.Ticks % 2 == 1))
                {
                        explosion.IsFinished = true;
                }
            }
        }
        private FallingObject AddFallingObject(FallingObjectFactory fallingobjectfactory, Window window)
        {
            int number = SplashKit.Rnd(1, 5);
            FallingObject fallingobject = fallingobjectfactory.Create(number, window);
            return fallingobject;  
        }

        public void SpawnFallingObject(Window window)
        {
            FallingObjectFactory fallingobjectfactory = new FallingObjectFactory();
            FallingObject fallobject = AddFallingObject(fallingobjectfactory, window);
            if (SplashKit.Rnd(1, 500) < 4)
            {
                _fallingobjectmanager.AddFallingObject(fallobject);
            }
        }
        public void BulletCollision(Window window) //  bullets and the object that collide with bullet
        {
            foreach (Bullet bullet in bulletlist)
            {
                foreach (FallingObject fallingobject in _fallingobjectmanager.FallingObjectList)
                {
                    if (CheckCollision(bullet, fallingobject))
                    {
                        if (fallingobject.Name == "boss" || fallingobject.Name == "minion")
                        {
                            removebullet.Add(bullet);
                            fallingobject.Health -= 1;
                            if (fallingobject.Health == 0)
                            {
                                removefallingobject.Add(fallingobject);
                            }
                            explosionlist.Add(new Explosion(window, bullet.X, bullet.Y));
                        }
                        FinishingExplosion();
                    }
                }
            }
            foreach (Bullet bullet in removebullet)
            {
                bulletlist.Remove(bullet);
            }
            foreach (FallingObject fallingobject in removefallingobject)
            {
                _fallingobjectmanager.RemoveFallingObject(fallingobject);
            }
        }

     
        public void FallingObjectWhenCollideWithPlayerAndAlly(Window window) // delete object when collide with player and applying special effects 
        {
            foreach (FallingObject fallingobject in _fallingobjectmanager.FallingObjectList)
            {
                if (CheckCollision (fallingobject, player))
                {
                    removefallingobject.Add(fallingobject);
                    if (fallingobject.Name == "minion")
                    {
                        player.Health -= 1;
                        explosionlist.Add(new Explosion(window, player.X, player.Y));
                        FinishingExplosion();
                    }
                    if (fallingobject.Name == "heart")
                    {
                        if (player.Health < 10)
                        {
                            player.Health += 1;
                        }
                    }
                    if (fallingobject.Name == "boss")
                    {
                        Initialize_End("hit_by_boss");
                    }
                    if (fallingobject.Name == "ability")
                    {
                        allylist.Add(new Ally(window));
                    }
                }
            }
            foreach (FallingObject fallingobject in removefallingobject)
            {
                _fallingobjectmanager.RemoveFallingObject(fallingobject);
            }

            foreach (FallingObject fallingobject in _fallingobjectmanager.FallingObjectList)
            {
                foreach (Ally ally in allylist)
                {
                    if (CheckCollision(ally, fallingobject))
                    {
                        if (fallingobject.Name == "minion" || fallingobject.Name == "boss")
                        {
                            removefallingobject.Add(fallingobject);
                            explosionlist.Add(new Explosion(window, ally.X, ally.Y));
                            FinishingExplosion();
                        }
                    }
                }
            }
            foreach (FallingObject fallingobject in removefallingobject)
            {
                _fallingobjectmanager.RemoveFallingObject(fallingobject);
            }
        }       
        public void GameObjectOffScreen() // Remove object that run out of screen
        {
            // Remove redundant bullets
            foreach (Bullet bullet in bulletlist)
            {
                if (bullet.Onscreen() == false)
                {
                    removebullet.Add(bullet);
                }
            }
            foreach (Bullet bullet in removebullet)
            {
                bulletlist.Remove(bullet);
            }
            // Remove falling object
            
            foreach (FallingObject fallingobject in _fallingobjectmanager.FallingObjectList)
            {
                 if (fallingobject.Y > 640 + fallingobject.Radius)
                    {
                        removefallingobject.Add(fallingobject);
                    }
             }
             foreach (FallingObject fallingobject in removefallingobject)
            {
                _fallingobjectmanager.RemoveFallingObject(fallingobject);
            }
            
            // Remove finished explosion
            foreach (Explosion explosion in explosionlist)
            {
                if (explosion.IsFinished == true)
                {
                    removeexplosion.Add(explosion);
                }
            }
            foreach (Explosion explosion in removeexplosion)
            {
                explosionlist.Remove(explosion);
            }
            foreach (Ally ally in allylist)
            {
                if (ally.Y < 0)
                {
                    removeally.Add(ally);
                }
            }
            foreach (Ally ally in removeally)
            {
                allylist.Remove(ally);
            }
        }
        public void CheckEnding()
        {
            if (player.Health == 0)
            {
                Initialize_End("hit_by_enemy");
            }
          
            if (player.Y < - player.Radius)
            {
                Initialize_End("off_border");
            }
            foreach (FallingObject fallingobject in _fallingobjectmanager.FallingObjectList)
            {
                if (fallingobject.Name == "minion")
                {
                    if (fallingobject.Y > 640)
                    {
                        Initialize_End("minion_reach_base");
                    }
                }
                if (fallingobject.Name == "boss")
                {
                    if (fallingobject.Y > 640)
                    {
                        Initialize_End("boss_reach_base");
                    }
                        
                }
            }
        }   
        public void DrawStart()
        {
            SplashKit.DrawBitmap(startbackground, 0, 0);
            SplashKit.DrawBitmap(gamelogo, 250, 20);
            SplashKit.DrawTextOnBitmap(startbackground, startoption1, Color.Red, "Normal Font", 28, 350, 360);
            SplashKit.DrawTextOnBitmap(startbackground, startoption2, Color.Red, "Normal Font", 28, 350, 400);
        }
        
        public void DrawGame(Window window)
        {
            gamebackground.Draw();
            
            foreach (Bullet bullet in bulletlist)
            {
                bullet.Draw();
            }
            foreach (FallingObject fallingobject in _fallingobjectmanager.FallingObjectList)
            {
                fallingobject.Draw();
            }
            foreach (Explosion explosion in explosionlist)
            {
                explosion.Draw();   
            }
            foreach (Ally ally in allylist)
            {
                ally.Draw();
            }
            player.Draw();
        }
        public void DrawEnd()
        {
            Bitmap endbackground = new Bitmap("end", "C:\\Desktop\\OOP\\CustomProgram\\image\\gameover.png");
            SplashKit.DrawTextOnBitmap(endbackground,endmessage1, Color.Yellow, "Normal Font", 28, 250, 200);
            SplashKit.DrawTextOnBitmap(endbackground,endmessage2, Color.Yellow, "Normal Font", 28, 250, 250);
            SplashKit.DrawBitmap(endbackground, 0, 0);

        }
        public void Draw(Window window)
        {
            if (_scene == "start")
            {
                DrawStart();
            }
            else if (_scene == "game")
            {
                DrawGame(window);
            }
            else if (_scene == "end")
            {
                DrawEnd();
            }
        }
        public void Update(Window window)
        {
            if (_scene == "game")
            {
                UpdateGame(window);
            }
        }
        public void UpdateGame(Window window)
        {   
            
            foreach (Bullet bullet in bulletlist)
            {
                bullet.Move();
            }
            foreach (Ally ally in allylist)
            {
                ally.Move();
            }
             
            player.Move();
            foreach (FallingObject fallingobject in _fallingobjectmanager.FallingObjectList)
            {
                fallingobject.Move();
            }
            SpawnFallingObject(window);
            BulletCollision(window);
            GameObjectOffScreen();
            BulletCollision(window);
            FallingObjectWhenCollideWithPlayerAndAlly(window);
            CheckEnding();        
        }
    }
}
