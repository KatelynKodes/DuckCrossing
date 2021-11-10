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

        private Camera3D _camera = new Camera3D();

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
            InitializeCamera();


            //player
            Player player = new Player(0, 0, 50f, "Player", Shape.SPHERE);
            AABBCollider PlayerAABB = new AABBCollider(50, 50, player);
            CircleCollider playerCircleCollider = new CircleCollider(2, player);
            player.Collider = PlayerAABB;
            player.SetColor(new Vector4(140, 120, 50, 255));
            player.SetScale(1, 1, 1);

            //Adds actors to the scene;
            scene.AddActor(player);
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
            Raylib.BeginMode3D(_camera);
            Raylib.DrawGrid(50, 1);
            Raylib.ClearBackground(Color.BLACK);

            //Adds all actor icons to buffer
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndMode3D();
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
        /// Initializes the game camera.
        /// </summary>
        private void InitializeCamera()
        {
            _camera.position = new System.Numerics.Vector3(0,10,10); //Camera Position
            _camera.target = new System.Numerics.Vector3(0, 0, 0); // Camera is focused on
            _camera.up = new System.Numerics.Vector3(0,1,0); // Camera up vector
            _camera.fovy = 45; // Camera field of view.
            _camera.projection = CameraProjection.CAMERA_PERSPECTIVE; //Camera mode type
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