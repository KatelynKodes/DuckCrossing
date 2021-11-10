using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Enemy : Actor
    {
        private float _speed;
        private Vector3 _velocity;
        private Actor _chasee;
        private float _maxViewingAngle;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector3 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Enemy (float x, float y, float speed, string name, float MaxAngle, Actor Chasee, Shape shape) :
            base(x, y,name, shape)
        {
            _maxViewingAngle = MaxAngle;
            _speed = speed;
            _chasee = Chasee;
        }

        /// <summary>
        /// Updates the chasers movement every frame 
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            //Finds the intended direction
            Vector3 MoveDirection = (_chasee.LocalPosition - LocalPosition).Normalized;

            //Normalizes the intended direction and multiplies it by speed and time
            Velocity = MoveDirection.Normalized * Speed * deltaTime;

            if (GetTargetInSight())
            {
                //Adds the velocity to the position
                LocalPosition += Velocity;
            }

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }

        /// <summary>
        /// Checks whether target is in range
        /// </summary>
        /// <returns> bool depending on if the targets dotproduct is less than 0 and if the distance between the chaser is
        /// less than or equal to a specified distance</returns>
        public bool GetTargetInSight()
        {
            Vector3 TargetDir = (_chasee.LocalPosition - LocalPosition).Normalized;

            float DotProduct = Vector3.DotProduct(TargetDir, Forward);
            float Angle = MathF.Acos(DotProduct);
            float Distance = Vector3.Distance(_chasee.LocalPosition, LocalPosition);
            return Angle < _maxViewingAngle && Distance <= 150f;
        }
    }
}