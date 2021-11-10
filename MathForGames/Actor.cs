using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{

    class Actor
    {
        private string _name;
        private bool _started;
        private Sprite _sprite;
        private Collider _collider;

        //transforms
        private Matrix3 _localTransform = Matrix3.Identity;
        private Matrix3 _globalTransform = Matrix3.Identity;
        private Matrix3 _translate = Matrix3.Identity;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;

        //Parents and children
        private Actor[] _children = new Actor[0];
        private Actor _parent;

        public bool Started
        {
            get { return _started; }
        }

        public Vector2 LocalPosition
        {
            get { return new Vector2(_translate.M02, _translate.M12); }
            set{ SetTranslation(value.X, value.Y);}
        }

        public Vector2 WorldPosition
        {
            get { return new Vector2(_globalTransform.M02, _globalTransform.M12); }
            set 
            {
                if (_parent != null)
                {
                    Vector2 NewLocal = new Vector2(value.X - _parent.LocalTransform.M02/_parent._scale.M00, 
                                                   value.Y - _parent.LocalTransform.M12/_parent._scale.M11);
                    LocalPosition = NewLocal;
                }
                else
                {
                    LocalPosition = value;
                }
            }
        }

        public Matrix3 LocalTransform
        {
            get { return _localTransform; }
            private set { _localTransform = value; }
        }

        public Matrix3 GlobalTransform
        {
            get { return _globalTransform; }
            private set { _globalTransform = value; }
        }

        public Actor Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public Actor[] Children
        {
            get { return _children; }
        }

        public Vector2 Size
        {
            get 
            {
                float xScale = new Vector2(_scale.M00, _scale.M10).Magnitude;
                float yScale = new Vector2(_scale.M01, _scale.M11).Magnitude;

                return new Vector2(xScale, yScale);
            }
            set { SetScale(value.X, value.Y); }
        }

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Collider Collider
        {
            get { return _collider; }
            set { _collider = value; }
        }

        public Vector2 Forward
        {
            get { return new Vector2(_rotation.M00, _rotation.M10); }
            set 
            { 
                Vector2 point = value.Normalized + LocalPosition;
                LookAt(point);

            }
        }

        public Actor(float x, float y, string name = "Actor", string path = "") :
            this(new Vector2 {X = x, Y = y}, name, path){ }


        public Actor(Vector2 position, string name = "Actor", string path = "")
        {
            LocalPosition = position;
            _name = name;

            if (path != "")
            {
                _sprite = new Sprite(path);
            }
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime)
        {
            UpdateTransforms();
        }

        public virtual void Draw()
        {
            if (_sprite != null)
            {
                _sprite.Draw(GlobalTransform);
            }
        }

        public void End()
        {

        }

        /// <summary>
        /// Updates both the local and global transforms of the actor
        /// </summary>
        public void UpdateTransforms()
        {
            _localTransform = _translate * _rotation * _scale;

            if (Parent != null)
            {
                GlobalTransform = Parent._globalTransform * _localTransform;
            }
            else
            {
                GlobalTransform = LocalTransform;
            }
        }

        //Adding and removing children

        /// <summary>
        /// Adds a child to an actor
        /// </summary>
        /// <param name="childToAdd"> The child to add to an actor </param>
        public void AddChild(Actor childToAdd)
        {
            Actor[] TempChildren = new Actor[Children.Length + 1];

            for (int i = 0; i < Children.Length; i++)
            {
                TempChildren[i] = Children[i];
            }

            TempChildren[TempChildren.Length - 1] = childToAdd;

            childToAdd.Parent = this;

            _children = TempChildren;
        }

        /// <summary>
        /// Removes a child from the children array
        /// </summary>
        /// <param name="childToRemove"></param>
        public void RemoveChild(Actor childToRemove)
        {
            bool childRemoved = false;
            Actor[] TempChildren = new Actor[Children.Length - 1];

            int j = 0;
            for (int i = 0; i < Children.Length; i++)
            {
                if (Children[i] != childToRemove)
                {
                    TempChildren[j] = Children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }
            }

            if (childRemoved)
            {
                _children = TempChildren;
                childToRemove.Parent = null;
            }
        }


        //Collision

        /// <summary>
        /// Checks if this actor collided with another actor
        /// </summary>
        /// <param name="other">The actor to check for a collision against</param>
        /// <returns>true if the distance between the actors is less than the radii of the two combined</returns>
        public virtual bool CheckForCollision(Actor other)
        {
            //return false automatically if either actor doesn't have a collider initialized
            if (Collider == null || other.Collider == null)
            {
                return false;
            }

            return Collider.CheckCollider(other);   
        }

        public virtual void OnCollision(Actor actor)
        {
        }


        //Scale, Translation, and Rotation

        /// <summary>
        /// Sets the scale of the actor
        /// </summary>
        /// <param name="x">The value to scale on the x axis.</param>
        /// <param name="y">The value to scale on the y axis.</param>
        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(x, y);
        }

        /// <summary>
        /// Scales the actor by a given amount
        /// </summary>
        /// <param name="x">The value to scale on the x axis.</param>
        /// <param name="y">The value to scale on the y axis.</param>
        public void Scale(float x, float y)
        {
            _scale *= Matrix3.CreateScale(x, y);
        }

        /// <summary>
        /// Sets the position of the actor
        /// </summary>
        /// <param name="Translationx">The new x position</param>
        /// <param name="Translationy">The new y position</param>
        public void SetTranslation(float Translationx, float Translationy)
        {
            _translate = Matrix3.CreateTranslation(Translationx, Translationy);
        }

        /// <summary>
        /// Translates the actor by a given amount.
        /// </summary>
        /// <param name="translationX">The amount to move on the x</param>
        /// <param name="translationY">The amount to move on the y</param>
        public void Translate(float translationX, float translationY)
        {
            _translate *= Matrix3.CreateTranslation(translationX, translationY);
        }

        /// <summary>
        /// Sets the rotation of the actor
        /// </summary>
        /// <param name="radians">The angle of the new rotation in radians.</param>
        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        /// <summary>
        /// Adds a rotation to the given transforms rotation
        /// </summary>
        /// <param name="radians">The angle in radians to turn.</param>
        public void Rotate(float radians)
        {
            _rotation *= Matrix3.CreateRotation(radians);
        }


        /// <summary>
        /// Rotates actor to face the given position
        /// </summary>
        /// <param name="position"></param>
        public void LookAt(Vector2 position)
        {
            //Find the direction the actor should look in
            Vector2 Direction = (position - LocalPosition).Normalized;

            //Use dotproduct to find the angle the actor needs to rotate
            float dotProd = Vector2.DotProduct(Direction, Forward);
            float angle = (float)Math.Acos(dotProd);

            //Find a perpendicular vector to the distance
            Vector2 perpDirection = new Vector2(Direction.Y, -Direction.X);

            //Find the dotProduct of the perpendicular vector and the current forward
            float perpDot = Vector2.DotProduct(perpDirection, Forward);

            //If the result isn't 0, change the sign of the angle to be either positive or negative
            if (perpDot != 0)
            {
                angle *= -perpDot / Math.Abs(perpDot);
            }

            Rotate(angle);
        }
    }
}