using System;
namespace Pong
{
    public class RiggedBallInitializer : IBallInitializer
    {
        public Point SpawnVelocity { get; set; }

        public void Initialize(IBall ball)
        {
            ball.Velocity = SpawnVelocity;
        }
    }
}

