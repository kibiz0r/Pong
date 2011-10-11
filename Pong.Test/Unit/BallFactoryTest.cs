using System;
using NUnit.Framework;

namespace Pong.Test
{
    [TestFixture]
    public class BallFactoryTest : TestHelper
    {
        [Test]
        public void Create_sets_position()
        {
            var ballFactory = new BallFactory();
            var ball = ballFactory.Create(new Point(16, 72));
            Assert.That(ball.Position, Is.EqualTo(new Point(16, 72)));
        }
    }
}

