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
            Raylib.DrawText(_icon.Symbol.ToString(), (int)GetPosition.X, (int)GetPosition.Y, 50, _icon.color);
        }

        public void End()
        {

        }

        public virtual void OnCollision(Actor actor)
        {
        }
    }
}