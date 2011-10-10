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
            Keyboard = Stub<IKeyboardInput>();
            Input = new PongInput(Keyboard.Object);
        }

        [Test]
        public void Calls_Join_when_player_presses_start()
        {
            var playerSlot1 = Stub<IPlayerSlot>();
            playerSlot1.Setup(p => p.StartKey).Returns(Key.Enter);
            var playerSlot2 = Stub<IPlayerSlot>();
            playerSlot2.Setup(p => p.StartKey).Returns(Key.Tab);

            Keyboard.Setup(k => k.IsPressed(Key.Enter)).Returns(true);
            Keyboard.Setup(k => k.IsPressed(Key.Tab)).Returns(false);

            var game = Mock<IPongGame>();
            game.Setup(g => g.PlayerSlots).Returns(new IPlayerSlot[] { playerSlot1.Object, playerSlot2.Object });
            game.Setup(g => g.Join(playerSlot1.Object));

            Input.Apply(game.Object);
        }

        [Test]
        public void Calls_Join_when_both_players_press_start()
        {
            var playerSlot1 = Stub<IPlayerSlot>();
            playerSlot1.Setup(p => p.StartKey).Returns(Key.Enter);
            var playerSlot2 = Stub<IPlayerSlot>();
            playerSlot2.Setup(p => p.StartKey).Returns(Key.Tab);

            Keyboard.Setup(k => k.IsPressed(Key.Enter)).Returns(true);
            Keyboard.Setup(k => k.IsPressed(Key.Tab)).Returns(true);

            var game = Mock<IPongGame>();
            game.Setup(g => g.PlayerSlots).Returns(new IPlayerSlot[] { playerSlot1.Object, playerSlot2.Object });
            game.Setup(g => g.Join(playerSlot1.Object));
            game.Setup(g => g.Join(playerSlot2.Object));

            Input.Apply(game.Object);
        }
    }
}

