using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Car: Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Vector2 _startingPos;
        private Vector2 _endingPos;
        private bool _reachedEnd;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Car(float x, float y, float speed, Vector2 endingPos, string name, string path) : base(x, y, name, path)
        {
            _startingPos = new Vector2(x, y);
            _endingPos = endingPos;
            _speed = speed;
        }

        public override void Update(float DeltaTime)
        {
            Vector2 moveDir = new Vector2();

            if (LocalPosition == _endingPos)
            {
                moveDir = (_endingPos - LocalPosition).Normalized;
            }
            else if (LocalPosition == _startingPos)
            {
                moveDir = (_startingPos - LocalPosition).Normalized;
            }

            _velocity = moveDir * Speed * DeltaTime;
            LocalPosition += _velocity;

            base.Update(DeltaTime);
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Player)
            {
                // Kill the player and end the game
            }
            else if (actor is Collectable)
            {
                // Kill the chick
            }
        }
    }
}
