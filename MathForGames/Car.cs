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
        private float _maxY;
        private float _var = 0f;

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

        public Car(float x, float y, float speed, float maxY, string name, string path) : base(x, y, name, path)
        {
            _maxY = maxY;
            _speed = speed;
        }

        public override void Update(float DeltaTime)
        {
            Vector2 Movedir = new Vector2(0, _maxY) * MathF.Cos(_var + DeltaTime);
            Velocity = Movedir * Speed;
            LocalPosition += Velocity * _speed;
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
