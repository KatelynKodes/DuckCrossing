﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class CircleCollider: Collider
    {
        private float _collisionRadius;

        public float CollisionRadius
        {
            get { return _collisionRadius; }
            set { _collisionRadius = value; }

        }

        public CircleCollider(float collisionRadius, Actor owner) : base(owner, ColliderType.CIRCLE)
        {
            _collisionRadius = collisionRadius;
        }

        public override void Draw()
        {
            base.Draw();
            Raylib.DrawCircleLines((int)Owner.GetPosition.X, (int)Owner.GetPosition.Y, _collisionRadius, Color.GREEN);
        }

        public override bool CheckCollisionCircle(CircleCollider other)
        {
            if (other.Owner == Owner)
            {
                return false;
            }

            //find distance between the two actors
            float distance = Vector2.Distance(other.Owner.GetPosition, Owner.GetPosition);
            float combinedRadii = other.CollisionRadius + CollisionRadius;

            return distance <= combinedRadii;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool CheckCollisionAABB(AABBCollider other)
        {
            //Returns false if this collider is checking collision against itself.
            if (other.Owner == Owner)
                return false;

            //Get the direction from this collider to the AABB
            Vector2 direction = Owner.GetPosition - other.Owner.GetPosition;

            //Clamp the direction vector to be within the bound of the AABB
            direction.X = Math.Clamp(direction.X, -other.Width/2, other.Width/2);
            direction.Y = Math.Clamp(direction.Y, -other.Height/2, other.Height/2);

            //Add the direction vector to the AABB center to get the closest point to the circle
            Vector2 ClosestPoint = other.Owner.GetPosition + direction;

            //Find the distance from the circles center to the closest point
            float distFromClosestPoin = Vector2.Distance(Owner.GetPosition, ClosestPoint);

            //Return whether or not the distance is less than the circles radius
            return distFromClosestPoin <= CollisionRadius;
        }
    }
}
