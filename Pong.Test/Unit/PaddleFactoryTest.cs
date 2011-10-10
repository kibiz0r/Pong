using System;
using NUnit.Framework;

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

        [SetUp]
        public void SetUp()
        {
            PaddleFactory = new PaddleFactory();
        }

        [Test]
        public void Creates_a_paddle_at_a_position()
        {
            var paddle = PaddleFactory.Create(new Point(33, 44));
            Assert.That(paddle.Position, Is.EqualTo(new Point(33, 44)));
        }
    }
}

