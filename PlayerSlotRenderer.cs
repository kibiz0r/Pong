using System;
namespace Pong
{
    public class PlayerSlotRenderer : IPlayerSlotRenderer
    {
        public PlayerSlotRenderer(IFontRenderer fontRenderer)
        {
            this.fontRenderer = fontRenderer;
        }
        private readonly IFontRenderer fontRenderer;

        public void Render(IPlayerSlot playerSlot)
        {
            fontRenderer.Render(playerSlot.Color, playerSlot.JoinReadyPosition, playerSlot.JoinReadyFontDrawFlags, playerSlot.Ready ? playerSlot.ReadyText : playerSlot.JoinText);
        }
    }
}

