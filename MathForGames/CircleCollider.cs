using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class CircleCollider: Collider
    {
        //Variables
        private float _collisionRadius;

        /// <summary>
        /// Returns and sets the variable of the _collisionradius variable
        /// </summary>
        public float CollisionRadius
        {
            get { return _collisionRadius; }
            set { _collisionRadius = value; }

        }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="collisionRadius"> The collisionradius of the circlecollider </param>
        /// <param name="owner"> Owner of the circleCollider </param>
        public CircleCollider(float collisionRadius, Actor owner) : base(owner, ColliderType.CIRCLE)
        {
            _collisionRadius = collisionRadius;
        }

        /// <summary>
        /// Draws circle lines on the Raylib window where the circle collider should be
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            Raylib.DrawCircleLines((int)Owner.LocalPosition.X, (int)Owner.LocalPosition.Y, _collisionRadius, Color.GREEN);
        }

        /// <summary>
        /// Checks collision with another circleCollider
        /// </summary>
        /// <param name="other"> the other circlecollider being checked</param>
        /// <returns> true if distance <= combinedRadii</returns>
        public override bool CheckCollisionCircle(CircleCollider other)
        {
            if (other.Owner == Owner)
            {
                return false;
            }

            //find distance between the two actors
            float distance = Vector2.Distance(other.Owner.LocalPosition, Owner.LocalPosition);
            float combinedRadii = other.CollisionRadius + CollisionRadius;

            return distance <= combinedRadii;
        }

        /// <summary>
        /// Checks collision with an AABB Collider
        /// </summary>
        /// <param name="other"> The AABB Collider being checked </param>
        /// <returns> Returns true if distFromClosestPoin <= CollisionRadius</returns>
        public override bool CheckCollisionAABB(AABBCollider other)
        {
            //Returns false if this collider is checking collision against itself.
            if (other.Owner == Owner)
                return false;

            //Get the direction from this collider to the AABB
            Vector2 direction = Owner.LocalPosition - other.Owner.LocalPosition;

            //Clamp the direction vector to be within the bound of the AABB
            direction.X = Math.Clamp(direction.X, -other.Width/2, other.Width/2);
            direction.Y = Math.Clamp(direction.Y, -other.Height/2, other.Height/2);

            //Add the direction vector to the AABB center to get the closest point to the circle
            Vector2 ClosestPoint = other.Owner.LocalPosition + direction;

            //Find the distance from the circles center to the closest point
            float distFromClosestPoin = Vector2.Distance(Owner.LocalPosition, ClosestPoint);

            //Return whether or not the distance is less than the circles radius
            return distFromClosestPoin <= CollisionRadius;
        }
    }
}
