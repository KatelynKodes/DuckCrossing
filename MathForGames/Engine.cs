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
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex = 0;
        private static Scene[] _scenes = new Scene[0];
        private Stopwatch _stopwatch = new Stopwatch();
        private int _maxChicks;

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
        /// Called when the application starts, initializes actors in scenes
        /// Also initializes starting values
        /// </summary>
        private void Start()
        {
            _stopwatch.Start();

            //Create Window using raylib
            Raylib.InitWindow(800, 800, "Duck Crossing");
            Scene CrossingScene = new Scene(Color.DARKGREEN);
            Scene WinningScene = new Scene(Color.LIME);
            Scene LosingScene = new Scene(Color.RED);

            //Defining the Player
            Player MotherDuck = new Player(400, 750, 200f, "Duck", "");
            MotherDuck.Collider = new AABBCollider(50, 50, MotherDuck);

            //Ducklings
            Collectable Duckling1 = new Collectable(500, 500, 100f, "Duckling1", "");
            Duckling1.Collider = new CircleCollider(20, Duckling1);

            Collectable Duckling2 = new Collectable(94, 100, 100f, "Duckling2", "");
            Duckling2.Collider = new CircleCollider(20, Duckling2);

            Collectable Duckling3 = new Collectable(500, 300, 100f, "Duckling3", "");
            Duckling3.Collider = new CircleCollider(20, Duckling3);

            Collectable Duckling4 = new Collectable(60, 300, 100f, "Duckling4", "");
            Duckling4.Collider = new CircleCollider(20, Duckling4);

            _maxChicks = 4;

            //The cars
            Car car1 = new Car(150, 130, 5f, "car1", "");
            car1.Collider = new AABBCollider(50, 115, car1);

            Car car2 = new Car(280, 750, 5f, "car2", "");
            car2.Collider = new AABBCollider(50, 115, car2);

            Car car3 = new Car(550, 130, 5f, "car3", "");
            car3.Collider = new AABBCollider(50, 115, car3);

            Car car4 = new Car(680, 750, 5f, "car4", "");
            car4.Collider = new AABBCollider(50, 115, car4);

            //Streets
            Actor Street1 = new Actor(100, 70, "Street1", "");
            Street1.Collider = new AABBCollider(100, 800, Street1);

            Actor Street2 = new Actor(230, 70, "Street2", "");
            Street2.Collider = new AABBCollider(100, 900, Street2);

            Actor Street3 = new Actor(500, 70, "Street3", "");
            Street3.Collider = new AABBCollider(100, 900, Street3);

            Actor Street4 = new Actor(630, 70, "Street4", "");
            Street4.Collider = new AABBCollider(100, 900, Street4);


            //UI Text
            UIText Instructions = new UIText(0, 0, "Instructions Text", "", 
                "Use 'W, A, S, D' keys to move, run into ducklings to catch them. Use left 'SHIFT' to run", 800, 70, 20, Color.BLACK);
            UIText CaughtText = new UIText(620, 40, "CaughtText", "", "", 200, 20, 20);
            ScoreHolder ScoreCounter = new ScoreHolder(0, 40, "Scorecounter", "", MotherDuck, CaughtText);

            UIText WinningMessage = new UIText(50, 300, "Winning Message", "",
                "You Win! The ducklings are safe", 800, 300, 50);
            UIText LosingMessage = new UIText(150, 300, "Losing Message", "",
                "You Lose! You died before you could grab all your ducklings.", 600, 300, 40);
            UIText CloseWindowMessage = new UIText(250, 700, "CloseWindowMessage", "", "You may now close the software", 350, 70, 20);

            //Adding actors to the crossing scene
            CrossingScene.AddActor(MotherDuck);
            CrossingScene.AddActor(Duckling1);
            CrossingScene.AddActor(Duckling2);
            CrossingScene.AddActor(Duckling3);
            CrossingScene.AddActor(Duckling4);
            CrossingScene.AddActor(car1);
            CrossingScene.AddActor(car2);
            CrossingScene.AddActor(car3);
            CrossingScene.AddActor(car4);
            CrossingScene.AddActor(Street1);
            CrossingScene.AddActor(Street2);
            CrossingScene.AddActor(Street3);
            CrossingScene.AddActor(Street4);
            CrossingScene.AddUIElement(Instructions);
            CrossingScene.AddUIElement(CaughtText);
            CrossingScene.AddUIElement(ScoreCounter);

            //Adding UI to the Winning and Losing Screens
            WinningScene.AddUIElement(WinningMessage);
            WinningScene.AddUIElement(CloseWindowMessage);
            LosingScene.AddUIElement(LosingMessage);
            LosingScene.AddUIElement(CloseWindowMessage);

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

            if (AllChicksCaught())
            {
                _currentSceneIndex = 1;
            }
            else if (CheckPlayerStatus())
            {
                _currentSceneIndex = 2;
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
            Raylib.ClearBackground(Color.BLACK);

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


        //Closes the Application
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }


        /// <summary>
        /// grabs an instance of a Player from the scene at the current scene index and 
        /// checks to see if the number of children matches the maximum
        /// number of chicks the player has to collect.
        /// </summary>
        /// <returns> True if the player variable given has the same amount of children as the maximum number of chicks to collect </returns>
        private bool AllChicksCaught()
        {
            bool allChicksCaught = false;

            for (int i = 0; i < _scenes[_currentSceneIndex].Actors.Length; i++)
            {
                if (_scenes[_currentSceneIndex].Actors[i] is Player)
                {
                    Player tempPlayer = (Player)_scenes[_currentSceneIndex].Actors[i];
                    if (tempPlayer.CurrChildren == _maxChicks)
                    {
                        allChicksCaught = true;
                    }
                }
            }

            return allChicksCaught;
        }

        /// <summary>
        /// grabs an instance of the current player and checks if the player has died or not
        /// </summary>
        /// <returns> true if the player's IsDead bool is true </returns>
        private bool CheckPlayerStatus()
        {
            bool isDead = false;

            for (int i = 0; i < _scenes[_currentSceneIndex].Actors.Length; i++)
            {
                if (_scenes[_currentSceneIndex].Actors[i] is Player)
                {
                    Player tempPlayer = (Player)_scenes[_currentSceneIndex].Actors[i];
                    if (tempPlayer.IsDead)
                    {
                        isDead = true;
                    }
                }
            }

            return isDead;
        }
    }
}