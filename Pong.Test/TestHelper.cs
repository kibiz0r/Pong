using System;
using NUnit.Framework;
using Moq;
using AllegroSharp;
namespace Pong.Test
{
    public class TestHelper
    {
        public MockRepository Mocks;
        public MockRepository Stubs;

        public IPongGame Create2PlayerPongGame()
        {
            return new PongGame
            {
                PlayerSlots = new IPlayerSlot[] {
                    new PlayerSlot
                    {
                        StartKey = Key.F11
                    },
                    new PlayerSlot
                    {
                        StartKey = Key.F12
                    }
                }
            };
        }

        public Mock<T> Mock<T>() where T : class
        {
            return Mocks.Create<T>();
        }

        public Mock<T> Stub<T>() where T : class
        {
            return Stubs.Create<T>();
        }

        [SetUp]
        public void TestHelperSetUp()
        {
            Mocks = new MockRepository(MockBehavior.Strict);
            Stubs = new MockRepository(MockBehavior.Loose);
        }

        [TearDown]
        public void TestHelperTearDown()
        {
            Mocks.VerifyAll();
            Stubs.Verify(); // Only verifies expectations for which .Verifiable() was called.
        }
    }
}

