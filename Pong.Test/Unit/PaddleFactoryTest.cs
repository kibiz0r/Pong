using System;
using NUnit.Framework;
using Moq;
using AllegroSharp;

namespace Pong.Test
{
    [TestFixture]
    public class PaddleFactoryTest : TestHelper
    {
        public IPaddleFactory PaddleFactory
        {
            get;
            set;
        }
        public Mock<IPlayerSlot> PlayerSlot
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            PaddleFactory = new PaddleFactory();
            PlayerSlot = Stub<IPlayerSlot>();
        }

        [Test]
        public void Sets_spawn_position()
        {
            PlayerSlot.Setup(p => p.SpawnPosition).Returns(new Point(33, 44));
            var paddle = PaddleFactory.Create(PlayerSlot.Object);
            Assert.That(paddle.Position, Is.EqualTo(new Point(33, 44)));
        }

        [Test]
        public void Sets_color()
        {
            PlayerSlot.Setup(p => p.Color).Returns(new Color(0.8f, 0.9f, 0.7f));
            var paddle = PaddleFactory.Create(PlayerSlot.Object);
            Assert.That(paddle.Color, Is.EqualTo(new Color(0.8f, 0.9f, 0.7f)));
        }
    }
}

