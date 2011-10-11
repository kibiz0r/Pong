using System;
using NUnit.Framework;

namespace Pong.Test
{
    [TestFixture]
    public class InitializationTest : FunctionalTestHelper
    {
        [Test]
        public void Game_starting_spawns_paddles()
        {
            Start(Game);
            Assert.That(Game.Players[0].Paddle.Position, Is.EqualTo(Player1SpawnPosition));
            Assert.That(Game.Players[1].Paddle.Position, Is.EqualTo(Player2SpawnPosition));
        }

        [Test]
        public void Game_starting_spawns_ball()
        {
            Start(Game);
            Assert.That(Game.Ball.Position, Is.EqualTo(new Point(Width / 2, Height / 2)));
        }

        [Test]
        public void Game_starting_initializes_ball()
        {
            BallInitializer.SpawnVelocity = new Point(5, 8);
            Start(Game);
            Assert.That(Game.Ball.Velocity, Is.EqualTo(new Point(5, 8)));
        }
    }
}

