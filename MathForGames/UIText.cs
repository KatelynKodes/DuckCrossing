using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class UIText : Actor
    {
        public string Text;
        public int Width;
        public int Height;
        public int FontSize;
        public Font Font;

        public UIText(float x, float y, string name, string path, string text, int width, int height, int fontsize)
            :base(x, y, name, path)
        {
            Text = text;
            Width = width;
            Height = height;
            FontSize = fontsize;
            Font = Raylib.LoadFont("resources/fonts/pixelplay.png");
        }

        public override void Draw()
        {
            Rectangle textbox = new Rectangle(LocalPosition.X, LocalPosition.Y, Width, Height);
            Raylib.DrawTextRecEx(Font, Text, textbox, FontSize, 1, true, Color.WHITE, Color.BLACK);
        }
    }
}
