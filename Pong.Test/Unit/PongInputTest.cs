using System;
using NUnit.Framework;
using Moq;
using AllegroSharp;

namespace Pong.Test
{
    [TestFixture]
    public class PongInputTest : TestHelper
    {
        public IPongInput Input
        {
            get;
            set;
        }
        public Mock<IKeyboardInput> Keyboard
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            Keyboard = Mocks.Create<IKeyboardInput>();
            Input = new PongInput(Keyboard.Object);
        }

        [Test]
        public void Calls_Join_when_player_presses_start()
        {
            var playerSlot = Mocks.Create<IPlayerSlot>();
            var startKey = Key.Enter;
            playerSlot.Setup(p => p.StartKey).Returns(startKey);

            var game = Mocks.Create<IPongGame>();
            game.Setup(g => g.Join(playerSlot.Object));

            Keyboard.Setup(k => k.IsPressed(startKey)).Returns(true);

            Input.Apply(game.Object);
        }
    }
}

