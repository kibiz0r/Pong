using System;
using NUnit.Framework;
using Moq;

namespace Pong.Test
{
    [TestFixture]
    public class PlayerInitializerTest : TestHelper
    {
        public IPlayerInitializer PlayerInitializer
        {
            get;
            set;
        }
        public Mock<IPaddleFactory> PaddleFactory
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            PaddleFactory = Mock<IPaddleFactory>();
            PlayerInitializer = new PlayerInitializer(PaddleFactory.Object);
        }

        [Test]
        public void Initialize_spawns_a_paddle_at_slot_spawn_position()
        {
            var paddle = Stub<IPaddle>();
            PaddleFactory.Setup(p => p.Create(new Point(75, 125))).Returns(paddle.Object);
            var playerSlot = Stub<IPlayerSlot>();
            playerSlot.Setup(p => p.SpawnPosition).Returns(new Point(75, 125));
            var player = Stub<IPlayer>();
            player.Setup(p => p.Slot).Returns(playerSlot.Object);
            player.SetupSet(p => p.Paddle = paddle.Object);
            PlayerInitializer.Initialize(player.Object);
        }
    }
}

