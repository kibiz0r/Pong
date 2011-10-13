using System;
namespace Pong
{
    public class GameInitializer : IGameInitializer
    {
        public IPlayerInitializer PlayerInitializer
        {
            get;
            set;
        }
        public IBallFactory BallFactory
        {
            get;
            set;
        }
        public IBallInitializer BallInitializer
        {
            get;
            set;
        }
        public void Initialize(IPongGame game)
        {

        }
    }
}

