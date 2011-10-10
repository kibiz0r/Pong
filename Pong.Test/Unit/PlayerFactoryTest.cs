using System;
using NUnit.Framework;

namespace Pong.Test
{
    [TestFixture]
    public class PlayerFactoryTest : TestHelper
    {
        public IPlayerFactory PlayerFactory
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            PlayerFactory = new PlayerFactory();
        }

        [Test]
        public void Creates_a_player_with_slot()
        {
            var playerSlot = Stub<IPlayerSlot>().Object;
            var player = PlayerFactory.Create(playerSlot);
            Assert.That(player.Slot, Is.EqualTo(playerSlot));
        }
    }
}

