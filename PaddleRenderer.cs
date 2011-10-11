using System;
using AllegroSharp;
namespace Pong
{
    public class PaddleRenderer : IPaddleRenderer
    {
        public void Render(IPaddle paddle)
        {
            Primitives.DrawRectangle(
                paddle.Position.X - 10,
                paddle.Position.Y - 50,
                paddle.Position.X + 10,
                paddle.Position.Y + 50,
                paddle.Color, 1);
        }
    }
}

