using System;
using AllegroSharp;

namespace Pong
{
    public interface IFontRenderer
    {
        void Render(Color color, Point position, FontDrawFlags flags, string text);
    }
}

