using System;
using NUnit.Framework;
using Moq;
using AllegroSharp;
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
            Game = new PongGame(
                new PlayerSlot
                {
                    StartKey = Key.F11
                },
                new PlayerSlot
                {
                    StartKey = Key.F12
                }
            );
        }

        [TearDown]
        public void TearDown()
        {
            Mocks.VerifyAll();
        }
    }
}

