using System;
using NUnit.Framework;
using AllegroSharp;
using Moq;

namespace Pong.Test
{
    [TestFixture]
    public class PlayerSlotRendererTest : TestHelper
    {
        public IPlayerSlotRenderer PlayerSlotRenderer
        {
            get;
            set;
        }

        public Mock<IFontRenderer> FontRenderer
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            FontRenderer = Mock<IFontRenderer>();
            PlayerSlotRenderer = new PlayerSlotRenderer(FontRenderer.Object);
        }

        [Test]
        public void Render_prints_ready_text_when_player_slot_is_ready()
        {
            var playerSlot = Stub<IPlayerSlot>();
            playerSlot.Setup(p => p.Ready).Returns(true);
            playerSlot.Setup(p => p.Color).Returns(new Color(1, 0, 1));
            playerSlot.Setup(p => p.JoinReadyPosition).Returns(new Point(50, 100));
            playerSlot.Setup(p => p.JoinReadyFontDrawFlags).Returns(FontDrawFlags.AlignLeft);
            playerSlot.Setup(p => p.ReadyText).Returns("Ready Text");
            FontRenderer.Setup(f => f.Render(new Color(1, 0, 1), new Point(50, 100), FontDrawFlags.AlignLeft, "Ready Text"));
            PlayerSlotRenderer.Render(playerSlot.Object);
        }

        [Test]
        public void Render_prints_join_text_when_player_slot_is_not_ready()
        {
            var playerSlot = Stub<IPlayerSlot>();
            playerSlot.Setup(p => p.Ready).Returns(false);
            playerSlot.Setup(p => p.Color).Returns(new Color(1, 0, 1));
            playerSlot.Setup(p => p.JoinReadyPosition).Returns(new Point(50, 100));
            playerSlot.Setup(p => p.JoinReadyFontDrawFlags).Returns(FontDrawFlags.AlignLeft);
            playerSlot.Setup(p => p.JoinText).Returns("Join Text");
            FontRenderer.Setup(f => f.Render(new Color(1, 0, 1), new Point(50, 100), FontDrawFlags.AlignLeft, "Join Text"));
            PlayerSlotRenderer.Render(playerSlot.Object);
        }
    }
}

