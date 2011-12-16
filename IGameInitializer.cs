using System;
namespace Pong
{
    public interface IGameInitializer
    {
        void InitializeGame(IPongGame game);
    }
}

