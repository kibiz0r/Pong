using System;
using NUnit.Framework;

namespace Pong.Test
{
    [TestFixture]
    public class PlayerSlotTest : TestHelper
    {
        [Test]
        public void Join_makes_slot_ready()
        {
            var playerSlot = new PlayerSlot();
            Assert.False(playerSlot.Ready);
            playerSlot.Join(Mock<IPlayer>().Object);
            Assert.That(playerSlot.Ready);
        }
    }
}

