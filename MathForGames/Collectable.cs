using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Collectable : Actor
    {
        private float _speed;
        private Vector2 _velocity;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

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
