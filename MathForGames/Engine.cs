using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;
using System.Diagnostics;

namespace MathForGames
{
    class Engine
    {
        public static bool _applicationShouldClose = false;
        private static int _currentSceneIndex = 0;
        private static Scene[] _scenes = new Scene[0];
        private Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// Called to begin the application
        /// </summary>
        public void Run()
        {
            //Call start for the entire application
            Start();

            float currTime = 0;
            float lastTime = 0;
            float deltaTime = 0;

            //Loop until application is told to close
            while (!Raylib.WindowShouldClose() && !_applicationShouldClose)
            {
                //Get how much time has passed since the application started
                currTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                //Set deltatime to be the difference in time from the last time recorded to the current time recorded
                deltaTime = currTime - lastTime;

                Update(deltaTime);
                Draw();

                //Set the last time recorded to be the current time
                lastTime = currTime;
            }

            //Calll at the end of the entire application.
            End();
        }

        /// <summary>
        /// Called when the application starts
        /// </summary>
        private void Start()
        {
            _stopwatch.Start();

            //Create Window using raylib
            Raylib.InitWindow(800, 450, "MathForgames");
            Scene scene = new Scene();

            //player
            Player player = new Player(5, 10, 50f, "Player", "Images/player.png");
            AABBCollider PlayerAABB = new AABBCollider(50, 50, player);
            CircleCollider playerCircleCollider = new CircleCollider(2, player);
            player.Collider = PlayerAABB;
            player.SetScale(50, 50);
            player.SetTranslation(200, 200);

            //enemy
            Enemy actor = new Enemy(100, 5, 30f,"Actor", 20, player, "Images/enemy.png");
            CircleCollider EnemyCircleCollider = new CircleCollider(25, actor);
            AABBCollider EnemyAABB = new AABBCollider(50, 50, actor);
            actor.Collider = EnemyCircleCollider;
            actor.SetScale(50, 50);
            actor.Forward = new Vector2(700, 900);

            //Planets
            Actor Sun = new Actor(400, 170, "Sun", "Images/Sun.png");
            CircleCollider SunCollider = new CircleCollider(30, Sun);
            Sun.Collider = SunCollider;
            Sun.SetScale(100, 100);

            Actor Planet1 = new Actor(400, 60, "Planet 1", "Images/Planet.png");
            CircleCollider Planet1Collider = new CircleCollider(20, Planet1);
            Planet1.Collider = Planet1Collider;
            Planet1.SetScale(50, 50);

            Actor Planet2 = new Actor(200, 150, "Planet 2", "Images/Planet.png");
            CircleCollider Planet2Collider = new CircleCollider(20, Planet2);
            Planet2.Collider = Planet2Collider;
            Planet2.SetScale(50, 50);

            Actor Planet3 = new Actor(490, 200, "Planet 3", "Images/Planet.png");
            CircleCollider Planet3Collider = new CircleCollider(20, Planet3);
            Planet3.Collider = Planet3Collider;
            Planet3.SetScale(50, 50);

            Actor Planet4 = new Actor(310, 250, "Planet 4", "Images/Planet.png");
            CircleCollider Planet4Collider = new CircleCollider(20, Planet4);
            Planet4.Collider = Planet4Collider;
            Planet4.SetScale(50, 50);

            //Adds children to sun
            Sun.AddChild(Planet1);
            Sun.AddChild(Planet2);
            Sun.AddChild(Planet3);
            Sun.AddChild(Planet4);

            //Adds actors to the scene;
            scene.AddActor(player);
            scene.AddActor(actor);
            scene.AddActor(Sun);
            scene.AddActor(Planet1);
            scene.AddActor(Planet2);
            scene.AddActor(Planet3);
            scene.AddActor(Planet4);
            _scenes = new Scene[] { scene };

            //Starts the current scene
            _scenes[_currentSceneIndex].Start();
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        private void Update(float deltaTime)
        {
            _scenes[_currentSceneIndex].Update(deltaTime);

            

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Called At the end of the application
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
            Raylib.CloseWindow();
            Console.Clear();
            Console.ReadKey(true);
        }

        /// <summary>
        /// Called everytime the game loops to update visuals
        /// </summary>
        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            //Adds all actor icons to buffer
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();
        }

        /// <summary>
        /// Adds a new scene to the engines scene array
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        public int AddScene(Scene scene)
        {
            //Create Temporary Array
            Scene[] TempArray = new Scene[_scenes.Length + 1];

            //Copy all values into temporary array
            for (int i = 0; i < _scenes.Length; i++)
            {
                TempArray[i] = _scenes[i];
            }

            //Set the last index to be the new scene
            TempArray[_scenes.Length] = scene;

            //set the old array to the new array
            _scenes = TempArray;

            //Return the last index
            return _scenes.Length - 1;
        }


        /// <summary>
        /// Gets the next key in the input stream
        /// </summary>
        /// <returns>The key that was pressed</returns>
        public static ConsoleKey GetConsoleKey()
        {
            //If there is No Key being pressed...
            if (!Console.KeyAvailable)
            {
                //...Return
                return 0;
            }

            //Return the current key being pressed
            return Console.ReadKey(true).Key;
        }

        //Closes the Application
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }
    }
}