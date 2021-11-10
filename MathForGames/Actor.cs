using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    struct Icon
    {
        public char Symbol;
        public Color color;
    }

    class Actor
    {
        private Icon _icon;
        private string _name;
        private Vector2 _position;
        private bool _started;
        private Collider _collider;

        public bool Started
        {
            get { return _started; }
        }

        public Vector2 GetPosition
        {
            get { return _position; }
            set { _position = value; }
        }

        public Icon GetIcon
        {
            get { return _icon; }
        }

        public string GetName
        {
            get { return _name; }
        }

        public Collider Collider
        {
            get { return _collider; }
            set { _collider = value; }
        }

        public Actor(char icon, float x, float y, Color IconColor, string name = "Actor") :
            this(icon, new Vector2 { X = x, Y = y }, IconColor, name)
        { }

        public Actor(char CharIcon, Vector2 Position, Color IconColor, string name = "Actor")
        {
            _icon = new Icon { Symbol = CharIcon, color = IconColor };
            _position = Position;
            _name = name;
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime)
        {
            Console.WriteLine(GetName + ": (" + GetPosition.X + "," + GetPosition.Y + ")");
        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.Symbol.ToString(), (int)GetPosition.X-16, (int)GetPosition.Y-25, 50, _icon.color);
        }

        public void End()
        {

        }

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
    }
}