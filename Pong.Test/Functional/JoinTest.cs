using System;
using NUnit.Framework;

namespace Pong.Test
{
    [TestFixture]
    public class JoinTest : TestHelper
    {
        [SetUp]
        public void SetUp()
        {
            SetUp2PlayerPongGame();
        }

        [Test]
        public void Last_player_joining_starts_game()
        {
            Game.Join(new Player());
            Game.Join(new Player());
            Assert.That(Game.HasStarted);
        }
    }
}

