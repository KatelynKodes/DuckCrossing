using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        private Vector3 _velocity;
        private float _speed;

        public float GetSpeed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector3 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Player(float x, float y, float speed, string name = "Actor", Shape shape = Shape.CUBE) :
            base(x, y, name, shape)
        {
            _speed = speed;
        }

        /// <summary>
        /// Checks which button is pressed by the player, then moves the player object to that position
        /// Updates every frame
        /// </summary>
        public override void Update(float deltaTime)
        {
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A)) +
                Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            int zDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W)) +
                Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            Vector3 Movedirection = new Vector3(xDirection, 0, zDirection);

            Velocity = Movedirection.Normalized * _speed * deltaTime;

            LocalPosition += Velocity;

            base.Update(deltaTime);
        }


        /// <summary>
        /// Preforms an action if the position of the player is equal to the position of another actor
        /// or the child of an actor
        /// </summary>
        /// <param name="collider"> The actor the player collided with </param>
        public override void OnCollision(Actor collider)
        {
            if (collider is Enemy)
            {
                Engine.CloseApplication();
            }
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}