using System;
namespace Pong
{
    public class RandomBallInitializer : IBallInitializer
    {
        private Random random = new Random();

        public void Initialize(IBall ball)
        {
            ball.Velocity = new Point(random.Next(-10, 10), random.Next(-10, 10));
        }
    }
}

