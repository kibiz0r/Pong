using System;
using AllegroSharp;
namespace Pong
{
    public class FontRenderer : IFontRenderer
    {
        public Font Font
        {
            get;
            set;
        }

        public void Render(Color color, Point position, FontDrawFlags flags, string text)
        {
            Font.Draw(color, position.X, position.Y, flags, text);
        }
    }
}

