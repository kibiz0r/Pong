using System;
using NUnit.Framework;
using Moq;
using AllegroSharp;
namespace Pong.Test
{
    public class TestHelper
    {
        public Point Player1SpawnPosition = new Point(50, 100);
        public Point Player2SpawnPosition = new Point(250, 100);

        public PongGame Create2PlayerPongGame()
        {
            return new PongGame
            {
                PlayerInitializer = new PlayerInitializer(new PaddleFactory()),
                PlayerFactory = new PlayerFactory(),
                PlayerSlots = new IPlayerSlot[] {
                    new PlayerSlot
                    {
                        SpawnPosition = Player1SpawnPosition
                    },
                    new PlayerSlot
                    {
                        SpawnPosition = Player2SpawnPosition
                    }
                }
            };
        }

        public void Start(IPongGame game)
        {
            game.Join(game.PlayerSlots[0]);
            game.Join(game.PlayerSlots[1]);
        }

        public MockRepository Mocks;
        public MockRepository Stubs;

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

