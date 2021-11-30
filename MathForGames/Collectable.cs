using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Collectable : Actor
    {
        // Variables
        private float _speed;
        private Vector2 _velocity;

        /// <summary>
        /// Returns and sets the value of the _speed variable
        /// </summary>
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        /// <summary>
        /// Returns and sets the value of the _velocity variable
        /// </summary>
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="x"> x position of the collectable actor </param>
        /// <param name="y"> y position of the collectable actor </param>
        /// <param name="speed"> speed of the collectable actor </param>
        /// <param name="name"> Name of the collectable actor </param>
        /// <param name="path"> path of the collectable actor's sprite image </param>
        public Collectable(float x, float y, float speed, string name = "Actor", string path = "") : base(x, y, name, path)
        {
            _speed = speed;
        }

        /// <summary>
        /// If the collectable has a parent, it follows that parent
        /// Runs every frame
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            if (Parent != null && Parent is Player)
            {
                Vector2 MoveDir = (Parent.LocalPosition - LocalPosition).Normalized;
                Velocity = MoveDir * Speed * deltaTime;

                LocalPosition += Velocity;
            }
            base.Update(deltaTime);  
        }

        /// <summary>
        /// Draws Collectable to the raylib window as well as it's
        /// collider
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
