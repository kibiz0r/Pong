using System;
namespace Pong
{
    public class BallFactory : IBallFactory
    {
        public IBall Create(Point position)
        {
            return new Ball
            {
                Position = position
            };
        }
    }
}

