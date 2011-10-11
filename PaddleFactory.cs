using System;
namespace Pong
{
    public class PaddleFactory : IPaddleFactory
    {
        public IPaddle Create(IPlayerSlot playerSlot)
        {
            return new Paddle
            {
                Position = playerSlot.SpawnPosition,
                Color = playerSlot.Color
            };
        }
    }
}

