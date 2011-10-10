using System;
using AllegroSharp;

namespace Pong
{
    public class PongDisplay : IPongDisplay
    {
        public PongDisplay(IRenderer renderer, IPlayerSlotRenderer playerSlotRenderer)
        {
            this.renderer = renderer;
            this.playerSlotRenderer = playerSlotRenderer;
        }

        private IRenderer renderer
        {
            get;
            set;
        }
        private IPlayerSlotRenderer playerSlotRenderer
        {
            get;
            set;
        }

        public void Render(IPongGame game)
        {
            renderer.Clear();
            foreach (var playerSlot in game.PlayerSlots)
            {
                playerSlotRenderer.Render(playerSlot);
            }
            renderer.Flip();
        }
    }
}

