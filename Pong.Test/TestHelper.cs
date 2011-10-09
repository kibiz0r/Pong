using System;
using NUnit.Framework;
using Moq;
namespace Pong.Test
{
    public class TestHelper
    {
        public virtual IPongGame Game
        {
            get;
            set;
        }

        public MockRepository Mocks = new MockRepository(MockBehavior.Strict);

        public void SetUp2PlayerPongGame()
        {
            Game = new PongGame(2);
        }

        [TearDown]
        public void TearDown()
        {
            Mocks.VerifyAll();
        }
    }
}

