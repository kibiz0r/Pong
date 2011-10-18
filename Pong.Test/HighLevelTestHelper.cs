using System;
namespace Pong.Test
{
    public abstract class HighLevelTestHelper : TestHelper
    {
        public abstract IPongGame Game { get; set; }
        public abstract RiggedBallInitializer BallInitializer { get; set; }
        public PongGame Create2PlayerPongGame()
        {
            return new PongGame(null,
                new PlayerInitializer(
                    new PaddleFactory()
                ),
                new PlayerFactory(),
                new BallFactory(),
                BallInitializer
                )
            {
                PlayerSlots = new IPlayerSlot[]
                {
                    new PlayerSlot { SpawnPosition = Player1SpawnPosition },
                    new PlayerSlot { SpawnPosition = Player2SpawnPosition }
                }
            };
        }
    }
}

