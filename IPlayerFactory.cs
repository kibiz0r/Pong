using System;
namespace Pong
{
    public interface IPlayerFactory
    {
        IPlayer Create(IPlayerSlot slot);
    }
}

