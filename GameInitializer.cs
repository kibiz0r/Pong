using System;
namespace Pong
{
    public class GameInitializer : IGameInitializer
    {
        public GameInitializer(IPlayerInitializer playerInitializer, IBallFactory ballFactory, IBallInitializer ballInitializer)
        {
            this.playerInitializer = playerInitializer;
            this.ballFactory = ballFactory;
            this.ballInitializer = ballInitializer;
        }
        private readonly IPlayerInitializer playerInitializer;
        private readonly IBallInitializer ballInitializer;
        private readonly IBallFactory ballFactory;

        public void InitializeGame(IPongGame game)
        {

        }
    }
}

