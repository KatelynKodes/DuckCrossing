using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        // Variables 
        private Vector2 _velocity;
        private float _speed;
        private float _defaultSpeed;
        private bool _isDead;
        private int _currChildren;

        /// <summary>
        /// Returns and sets the _isDead variable
        /// </summary>
        public bool IsDead
        {
            get { return _isDead; }
            private set { _isDead = value; }
        }

        /// <summary>
        /// Returns and privately sets the _currChildren variable
        /// </summary>
        public int CurrChildren
        {
            get { return _currChildren; }
            private set { _currChildren = value; }
        }

        /// <summary>
        /// Returns and sets the _speed variable
        /// </summary>
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        /// <summary>
        /// Returns and sets the _velocity variable
        /// </summary>
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        /// <summary>
        /// Base Player constructor
        /// </summary>
        /// <param name="x"> x position of the player actor </param>
        /// <param name="y"> y position of the player actor </param>
        /// <param name="speed"> speed variable of the player actor </param>
        /// <param name="name"> name variable of the player actor </param>
        /// <param name="path"> path to the player actor's sprite image </param>
        public Player(float x, float y, float speed, string name = "Actor", string path = "") :
            base(x, y, name, path)
        {
            _speed = speed;
            _defaultSpeed = _speed;
            _isDead = false;
        }

        /// <summary>
        /// Checks which button is pressed by the player, then moves the player object to that position
        /// Updates every frame
        /// </summary>
        public override void Update(float deltaTime)
        {
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A)) +
                Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            int yDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W)) +
                Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
            {
                _speed += 0.4f;
            }
            else
            {
                _speed = _defaultSpeed;
            }

            Vector2 Movedirection = new Vector2(xDirection, yDirection);

            Velocity = Movedirection.Normalized * _speed * deltaTime;

            LocalPosition += _velocity;

            base.Update(deltaTime);
        }


        /// <summary>
        /// Preforms an action if the position of the player is equal to the position of another actor
        /// or the child of an actor
        /// </summary>
        /// <param name="collider"> The actor the player collided with </param>
        public override void OnCollision(Actor collider)
        {
            if (collider is Collectable && !ContainsChild(collider))
            {
                AddChild(collider);
                CurrChildren++;
            }
            else if(collider is Car)
            {
                IsDead = true;
            }
        }

        /// <summary>
        /// Calls the base draw method and the collider draw method
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}