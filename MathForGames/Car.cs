using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Car: Actor
    {
        ///Variables
        private float _speed;
        private Vector2 _startPosition;
        private float _frequency = 5f;
        private float _offset = 0f;
        private float _magnitude = 5f;
        private float _val = 0f;

        /// <summary>
        /// Returns and sets the _speed variable
        /// </summary>
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="x"> xposition of the car actor </param>
        /// <param name="y"> yposition of the car actor </param>
        /// <param name="speed"> Speed of the car actor </param>
        /// <param name="name"> name of the car actor </param>
        /// <param name="path"> path of the car actor sprite image </param>
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
