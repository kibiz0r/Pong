using System;
namespace Pong
{
    public interface IGameInitializer
    {
        void Initialize(IPongGame game);
    }
}

