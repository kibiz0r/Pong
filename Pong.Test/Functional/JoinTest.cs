using System;
using NUnit.Framework;

namespace Pong.Test
{
    [TestFixture]
    public class JoinTest : TestHelper
    {
        public IPongGame Game
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            Game = Create2PlayerPongGame();
        }

        [Test]
        public void Last_player_joining_starts_game()
        {
            Game.Join(Game.PlayerSlots[0]);
            Game.Join(Game.PlayerSlots[1]);
            Assert.That(Game.HasStarted);
        }

        [Test]
        public void Joining_multiple_times_is_okay()
        {
            Game.Join(Game.PlayerSlots[0]);
            Game.Join(Game.PlayerSlots[1]);
            Game.Join(Game.PlayerSlots[1]);
            Assert.That(Game.Players[1].Paddle, Is.Not.Null);
        }

        [Test]
        public void Game_starting_spawns_paddles()
        {
            Start(Game);
            Assert.That(Game.Players[0].Paddle.Position, Is.EqualTo(Player1SpawnPosition));
            Assert.That(Game.Players[1].Paddle.Position, Is.EqualTo(Player2SpawnPosition));
        }
    }
}

