using System;
namespace Pong.Test
{
    public abstract class HighLevelTestHelper : TestHelper
    {
        public abstract IPongGame Game { get; set; }
        public abstract RiggedBallInitializer BallInitializer { get; set; }
        public PongGame Create2PlayerPongGame()
        {
            return new PongGame
            {
                PlayerInitializer = new PlayerInitializer(
                    new PaddleFactory()
                ),
                PlayerFactory = new PlayerFactory(),
                BallFactory = new BallFactory(),
                BallInitializer = BallInitializer,
                PlayerSlots = new IPlayerSlot[]
                {
                    new PlayerSlot { SpawnPosition = Player1SpawnPosition },
                    new PlayerSlot { SpawnPosition = Player2SpawnPosition }
                }
            };
        }
    }
}

