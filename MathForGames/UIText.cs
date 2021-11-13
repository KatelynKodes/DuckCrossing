using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class UIText : Actor
    {
        private string _text;
        private int _width;
        private int _height;
        private int _fontSize;
        private Font _font;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public UIText(float x, float y, string name, string path, string text, int width, int height, int fontsize)
            :base(x, y, name, path)
        {
            Text = text;
            Width = width;
            Height = height;
            _fontSize = fontsize;
            _font = Raylib.LoadFont("resources/fonts/pixelplay.png");
        }

        public override void Draw()
        {
            Rectangle textbox = new Rectangle(LocalPosition.X, LocalPosition.Y, Width, Height);
            Raylib.DrawRectangleRec(textbox, Color.BLACK);
            Raylib.DrawTextRec(_font, Text, textbox, _fontSize, 1, true, Color.WHITE);
        }
    }
}
