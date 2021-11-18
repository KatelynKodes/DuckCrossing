using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Car: Actor
    {
        private float _speed;
        private Vector2 _startPosition;
        private float _frequency = 5f;
        private float _offset = 0f;
        private float _magnitude = 5f;
        private float _val = 0f;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Car(float x, float y, float speed, string name, string path) : base(x, y, name, path)
        {
            _startPosition = new Vector2(x, y);
            _speed = speed;
        }

        /// <summary>
        /// Moves car in an upward and downward hovering motion
        /// </summary>
        /// <param name="DeltaTime"></param>
        public override void Update(float DeltaTime)
        {
            LocalPosition = _startPosition + new Vector2(0,30) * MathF.Sin((_val += DeltaTime) * _frequency + _offset) * _magnitude * Speed;
            base.Update(DeltaTime);
        }

        /// <summary>
        /// Draws car to raylib window
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
