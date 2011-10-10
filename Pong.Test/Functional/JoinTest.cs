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
    }
}

