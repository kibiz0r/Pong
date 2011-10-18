using System;
using AllegroSharp;

namespace Pong
{
    public class PongDisplay : IPongDisplay
    {
        public PongDisplay(IScreenRenderer screenRenderer, IPlayerSlotRenderer playerSlotRenderer,
            IBallRenderer ballRenderer, IPaddleRenderer paddleRenderer)
        {
            this.screenRenderer = screenRenderer;
            this.playerSlotRenderer = playerSlotRenderer;
            this.ballRenderer = ballRenderer;
            this.paddleRenderer = paddleRenderer;
        }

        private readonly IScreenRenderer screenRenderer;
        private readonly IPlayerSlotRenderer playerSlotRenderer;
        private readonly IBallRenderer ballRenderer;
        private readonly IPaddleRenderer paddleRenderer;

        public void Render(IPongGame game)
        {
            screenRenderer.Clear();
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
            screenRenderer.Flip();
        }
    }
}

