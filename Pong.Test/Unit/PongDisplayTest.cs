using System;
using NUnit.Framework;
using Moq;

namespace Pong.Test
{
    [TestFixture]
    public class PongDisplayTest : TestHelper
    {
        public Mock<IRenderer> Renderer
        {
            get;
            set;
        }
        public Mock<IPongGame> Game
        {
            get;
            set;
        }
        public IPongDisplay Display
        {
            get;
            set;
        }
        public Mock<IPlayerSlotRenderer> PlayerSlotRenderer
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            Renderer = Stub<IRenderer>();
            Game = Stub<IPongGame>();
            PlayerSlotRenderer = Mock<IPlayerSlotRenderer>();
            Display = new PongDisplay(Renderer.Object, PlayerSlotRenderer.Object);
        }

        [Test]
        public void Render_clears_display()
        {
            Renderer.Setup(r => r.Clear()).Verifiable();
            Display.Render(Game.Object);
        }

        [Test]
        public void Render_flips_display()
        {
            Renderer.Setup(r => r.Flip()).Verifiable();
            Display.Render(Game.Object);
        }

        [Test]
        public void Render_renders_player_slots()
        {
            var playerSlot1 = Mock<IPlayerSlot>();
            var playerSlot2 = Mock<IPlayerSlot>();
            Game.Setup(g => g.PlayerSlots).Returns(new IPlayerSlot[] { playerSlot1.Object, playerSlot2.Object });
            PlayerSlotRenderer.Setup(s => s.Render(playerSlot1.Object));
            PlayerSlotRenderer.Setup(s => s.Render(playerSlot2.Object));
            Display.Render(Game.Object);
        }
    }
}

