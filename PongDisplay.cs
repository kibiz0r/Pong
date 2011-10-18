using System;
using AllegroSharp;

namespace Pong
{
    public class PongDisplay : IPongDisplay
    {
        public IScreenRenderer ScreenRenderer
        {
            get;
            set;
        }
        public IPlayerSlotRenderer PlayerSlotRenderer
        {
            get;
            set;
        }
        public IBallRenderer BallRenderer
        {
            get;
            set;
        }
        public IPaddleRenderer PaddleRenderer
        {
            get;
            set;
        }

        public void Render(IPongGame game)
        {
            ScreenRenderer.Clear();
            foreach (var playerSlot in game.PlayerSlots)
            {
                PlayerSlotRenderer.Render(playerSlot);
            }
            if (game.HasStarted)
            {
                BallRenderer.Render(game.Ball);
                foreach (var player in game.Players)
                {
                    PaddleRenderer.Render(player.Paddle);
                }
            }
            ScreenRenderer.Flip();
        }
    }
}

