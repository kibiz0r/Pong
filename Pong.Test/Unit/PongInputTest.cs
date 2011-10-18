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
        public Mock<IPlayerSlot> PlayerSlot1
        {
            get;
            set;
        }
        public Mock<IPlayerSlot> PlayerSlot2
        {
            get;
            set;
        }
        public Mock<IPongGame> Game
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            Keyboard = Stub<IKeyboardInput>();
            Input = new PongInput { KeyboardInput = Keyboard.Object };
            PlayerSlot1 = Stub<IPlayerSlot>();
            PlayerSlot1.Setup(p => p.StartKey).Returns(Key.Enter);
            PlayerSlot2 = Stub<IPlayerSlot>();
            PlayerSlot2.Setup(p => p.StartKey).Returns(Key.Tab);
            Game = Mock<IPongGame>();
            Game.Setup(g => g.PlayerSlots).Returns(new IPlayerSlot[] { PlayerSlot1.Object, PlayerSlot2.Object });
        }

        public void KeyIsPressed(Key key)
        {
            Keyboard.Setup(k => k.IsPressed(key)).Returns(true);
        }

        public void KeyIsNotPressed(Key key)
        {
            Keyboard.Setup(k => k.IsPressed(key)).Returns(false);
        }

        [Test]
        public void Calls_Join_when_player_presses_start()
        {
            KeyIsPressed(Key.Enter);
            KeyIsNotPressed(Key.Tab);

            Game.Setup(g => g.Join(PlayerSlot1.Object));

            Input.Apply(Game.Object);
        }

        [Test]
        public void Calls_Join_when_both_players_press_start()
        {
            KeyIsPressed(Key.Enter);
            KeyIsPressed(Key.Tab);

            Game.Setup(g => g.Join(PlayerSlot1.Object));
            Game.Setup(g => g.Join(PlayerSlot2.Object));

            Input.Apply(Game.Object);
        }

        [Test]
        public void Polls_keyboard()
        {
            Keyboard.Setup(k => k.Poll()).Verifiable();
            Input.Apply(Game.Object);
        }

        [Test]
        public void Checks_for_exit()
        {
            KeyIsPressed(Key.Escape);
            Game.Setup(g => g.Exit());
            Input.Apply(Game.Object);
        }
    }
}

