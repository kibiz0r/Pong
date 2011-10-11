using System;
using NUnit.Framework;

namespace Pong.Test
{
    [TestFixture]
    public class JoinTest : FunctionalTestHelper
    {
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
    }
}

