using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    /// <summary>
    /// An enum containing the types of collider
    /// </summary>
    enum ColliderType
    {
        CIRCLE,
        AABB
    }
    abstract class Collider
    {
        // Variables
        private Actor _owner;
        private ColliderType _colliderType;

        /// <summary>
        /// Returns and sets the _owner actor value
        /// </summary>
        public Actor Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        /// <summary>
        /// returns the _colliderType enum value.
        /// </summary>
        public ColliderType ColliderType
        {
            get { return _colliderType; }
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="colliderType"></param>
        public Collider(Actor owner, ColliderType colliderType)
        {
            _owner = owner;
            _colliderType = colliderType;
        }

        public virtual void Draw(){}

        /// <summary>
        /// Checks whether the actors collider is either a Circle or an
        /// AABB collider. Then calls appropriate method
        /// </summary>
        /// <param name="other"> Actor owning the collider being checked </param>
        /// <returns> A result of a method that reeturns a bool </returns>
        public bool CheckCollider(Actor other)
        {
            if (other.Collider.ColliderType == ColliderType.CIRCLE)
                return CheckCollisionCircle((CircleCollider)other.Collider);
            else if (other.Collider.ColliderType == ColliderType.AABB)
                return CheckCollisionAABB((AABBCollider)other.Collider);
            return false;
        }

        /// <summary>
        /// Checks collision with a CircleCollider, returns false at default
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool CheckCollisionCircle(CircleCollider other) { return false; }

        /// <summary>
        /// Checks collision with an AABB collider, returns false at default
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool CheckCollisionAABB(AABBCollider other) { return false;}
    }
}
