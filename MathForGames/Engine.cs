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
        private bool _playerDead;
        private int _ducklingsCaught;

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
            Raylib.InitWindow(800, 800, "Duck Crossing");
            Scene CrossingScene = new Scene(Color.DARKGREEN);
            Scene WinningScene = new Scene(Color.BLACK);
            Scene LosingScene = new Scene(Color.BLACK);

            //Defining the Player
            Player MotherDuck = new Player(400, 750, 50f, "Duck", "");
            MotherDuck.Collider = new AABBCollider(50, 50, MotherDuck);

            //Ducklings
            Collectable Duckling1 = new Collectable(500, 500, 40f, "Duckling1", "");
            Duckling1.Collider = new CircleCollider(20, Duckling1);

            Collectable Duckling2 = new Collectable(94, 100, 40f, "Duckling2", "");
            Duckling2.Collider = new CircleCollider(20, Duckling2);

            Collectable Duckling3 = new Collectable(500, 30, 40f, "Duckling3", "");
            Duckling3.Collider = new CircleCollider(20, Duckling3);

            Collectable Duckling4 = new Collectable(60, 300, 40f, "Duckling4", "");
            Duckling4.Collider = new CircleCollider(20, Duckling4);

            //The cars
            Car car1 = new Car(150, 10, 60f, new Vector2(150, 750), "car1", "");
            car1.Collider = new AABBCollider(50, 115, car1);

            Car car2 = new Car(280, 750, 60f, new Vector2(280, 10), "car2", "");
            car2.Collider = new AABBCollider(50, 115, car2);

            Car car3 = new Car(550, 10, 60f, new Vector2(550, 750), "car3", "");
            car3.Collider = new AABBCollider(50, 115, car3);

            Car car4 = new Car(680, 750, 60f, new Vector2(680, 10), "car4", "");
            car4.Collider = new AABBCollider(50, 115, car4);


            //UI Text
            UIText Instructions = new UIText(0, 0, "Instructions Text", "", 
                "Use the 'W, A, S, D' keys to move, run into ducklings to catch them.", 800, 70, 20);
            UIText CaughtText = new UIText(0, 40, "CaughtText", "", "Ducklings Caught: " + _ducklingsCaught, 200, 20, 20);

            //Adding actors to the scene
            CrossingScene.AddActor(MotherDuck);
            CrossingScene.AddActor(Duckling1);
            CrossingScene.AddActor(Duckling2);
            CrossingScene.AddActor(Duckling3);
            CrossingScene.AddActor(Duckling4);
            CrossingScene.AddActor(car1);
            CrossingScene.AddActor(car2);
            CrossingScene.AddActor(car3);
            CrossingScene.AddActor(car4);
            CrossingScene.AddUIElement(Instructions);
            CrossingScene.AddUIElement(CaughtText);

            _scenes = new Scene[] { CrossingScene, WinningScene, LosingScene };

            //Starts the current scene
            _scenes[_currentSceneIndex].Start();
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        private void Update(float deltaTime)
        {
            _scenes[_currentSceneIndex].Update(deltaTime);
            _scenes[_currentSceneIndex].UpdateUI(deltaTime);


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
        }

        /// <summary>
        /// Called everytime the game loops to update visuals
        /// </summary>
        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DARKGREEN);
            //Raylib.DrawRectangle(0, 0, 800, 70, Color.BLACK);

            //Street
            Raylib.DrawRectangle(100, 70, 100, 900, Color.GRAY);
            Raylib.DrawRectangle(230, 70, 100, 900, Color.GRAY);

            Raylib.DrawRectangle(500, 70, 100, 900, Color.GRAY);
            Raylib.DrawRectangle(630, 70, 100, 900, Color.GRAY);


            //Adds all actor icons to buffer
            _scenes[_currentSceneIndex].Draw();
            _scenes[_currentSceneIndex].DrawUI();

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