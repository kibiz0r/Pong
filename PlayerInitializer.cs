using System;
namespace Pong
{
    public class PlayerInitializer : IPlayerInitializer
    {
        public PlayerInitializer(IPaddleFactory paddleFactory)
        {
            this.paddleFactory = paddleFactory;
        }
        private IPaddleFactory paddleFactory;

        public void Initialize(IPlayer player)
        {
            player.Paddle = paddleFactory.Create(player.Slot);
        }
    }
}

