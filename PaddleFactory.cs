using System;
namespace Pong
{
    public class PaddleFactory : IPaddleFactory
    {
        public IPaddle Create(Point position)
        {
            return new Paddle
            {
                Position = position
            };
        }
    }
}

