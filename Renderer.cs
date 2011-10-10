using System;
using AllegroSharp;

namespace Pong
{
    public class Renderer : IRenderer
    {
        public void Clear()
        {
            Display.Clear(new Color(0, 0, 0));
        }

        public void Flip()
        {
            Display.Flip();
        }
    }
}

