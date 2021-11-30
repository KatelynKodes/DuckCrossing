using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class UIText : Actor
    {
        // Variables 
        private string _text;
        private int _width;
        private int _height;
        private int _fontSize;
        private Font _font;
        private Color _textboxColor;

        /// <summary>
        /// Returns and sets the _text variable
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// Returns and sets the _width variable
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Returns and sets the _height variable
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="x"> x position of the UIText </param>
        /// <param name="y"> y position of the UIText </param>
        /// <param name="name"> name of the UIText </param>
        /// <param name="path"> path of the UIText's sprite image </param>
        /// <param name="text"> text of the UIText </param>
        /// <param name="width"> The UIText's width </param>
        /// <param name="height"> The UIText's height </param>
        /// <param name="fontsize"> The size of the UIText's font </param>
        /// <param name="textboxColor"> The color of the UIText's textbox </param>
        public UIText(float x, float y, string name, string path, string text, int width, int height, int fontsize, Color textboxColor = new Color())
            :base(x, y, name, path)
        {
            Text = text;
            Width = width;
            Height = height;
            _fontSize = fontsize;
            _font = Raylib.LoadFont("resources/fonts/pixelplay.png");
            _textboxColor = textboxColor;
        }

        /// <summary>
        /// Draws the UItext to the raylib window, also creating a textbox of a specified color
        /// for the text to reside in.
        /// </summary>
        public override void Draw()
        {
            Rectangle textbox = new Rectangle(LocalPosition.X, LocalPosition.Y, Width, Height);
            Raylib.DrawRectangleRec(textbox, _textboxColor);
            Raylib.DrawTextRec(_font, Text, textbox, _fontSize, 1, true, Color.WHITE);
        }
    }
}
