using System;
using AllegroSharp;

namespace Pong
{
    public class PongDisplay : IPongDisplay
    {
        public PongDisplay(IRenderer renderer, IPlayerSlotRenderer playerSlotRenderer, IBallRenderer ballRenderer,
            IPaddleRenderer paddleRenderer)
        {
            this.renderer = renderer;
            this.playerSlotRenderer = playerSlotRenderer;
            this.ballRenderer = ballRenderer;
            this.paddleRenderer = paddleRenderer;
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
        private IBallRenderer ballRenderer
        {
            get;
            set;
        }
        private IPaddleRenderer paddleRenderer
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
            if (game.HasStarted)
            {
                ballRenderer.Render(game.Ball);
                foreach (var player in game.Players)
                {
                    paddleRenderer.Render(player.Paddle);
                }
            }
            renderer.Flip();
        }
    }
}

