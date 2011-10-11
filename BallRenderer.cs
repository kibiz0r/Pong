using System;
using AllegroSharp;

namespace Pong
{
    public class BallRenderer : IBallRenderer
    {
        public void Render(IBall ball)
        {
            Primitives.DrawRectangle(ball.Position.X - 5, ball.Position.Y - 5, ball.Position.X + 5, ball.Position.Y + 5, new Color(1, 1, 1), 1);
        }
    }
}

