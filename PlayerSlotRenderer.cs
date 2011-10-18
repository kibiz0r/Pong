using System;
namespace Pong
{
    public class PlayerSlotRenderer : IPlayerSlotRenderer
    {
        public IFontRenderer FontRenderer;

        public void Render(IPlayerSlot playerSlot)
        {
            FontRenderer.Render(playerSlot.Color, playerSlot.JoinReadyPosition, playerSlot.JoinReadyFontDrawFlags, playerSlot.Ready ? playerSlot.ReadyText : playerSlot.JoinText);
        }
    }
}

