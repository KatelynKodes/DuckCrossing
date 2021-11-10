using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class AABBCollider : Collider
    {
        private float _width;
        private float _height;


        /// <summary>
        /// The width property, gets and sets the width
        /// </summary>
        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// The height property, gets and sets the height
        /// </summary>
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Gets the left value by dividing width by 2 and subtracting from the owner's x-position
        /// </summary>
        public float Left
        {
            get 
            {
                return Owner.GetPosition.X - (_width/2);
            }
        }

        /// <summary>
        /// Gets the right value by dividing width by 2 and adding from the owner's x-position
        /// </summary>
        public float Right
        {
            get
            {
                return Owner.GetPosition.X + (_width/2);
            }
        }

        /// <summary>
        /// Gets the top value by dividing height by 2 and subtracting from the owner's y-position
        /// </summary>
        public float Top
        {
            get
            {
                return Owner.GetPosition.Y - (_height/2);
            }
        }

        /// <summary>
        /// Gets the bottom value by dividing width by 2 and adding from the owner's y-position
        /// </summary>
        public float Bottom
        {
            get
            {
                return Owner.GetPosition.Y + (_height/2);
            }
        }


        /// <summary>
        /// Constructor for a new AABBCollider
        /// </summary>
        /// <param name="width"> The width of the box </param>
        /// <param name="hieght"> The height of the box </param>
        /// <param name="owner"> the Actor the collider belongs to</param>
        public AABBCollider(float width, float hieght, Actor owner) : base(owner, ColliderType.AABB)
        {
            _width = width;
            _height = hieght;
        }

        public override void Draw()
        {
            Raylib.DrawRectangleLines((int)Left, (int)Top, (int)Width, (int)Height, Color.GREEN);
        }

        /// <summary>
        /// Calls the checkCollisionABB from the circlecollider
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool CheckCollisionCircle(CircleCollider other)
        {

            return other.CheckCollisionAABB(this);
        }


        /// <summary>
        /// Checks for a collision with another AABB collider
        /// </summary>
        /// <param name="other"> the other collider the method is checking collision against</param>
        /// <returns> True if there was a collision detected </returns>
        public override bool CheckCollisionAABB(AABBCollider other)
        {
            //Return false if this owner is checking for a collision against itself.
            if (other.Owner == Owner)
            {
                return false;
            }

            // Returns true if there is an overlap between boxes
            return (other.Left <= Right && //others Left is less than or equal to Right
                other.Top <= Bottom && //others Top is less than or equal to Botom
                Left <= other.Right && //Left is less than or equal to other's Right
                Top <= other.Bottom); //Top is less than or equal to other's Bottom
        }
    }
}
