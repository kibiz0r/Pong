using System;
using System.Collections.Generic;
namespace Pong
{
    public interface IPongGame
    {
        void Join(IPlayerSlot playerSlot);
        bool HasStarted
        {
            get;
        }
        IPlayer[] Players
        {
            get;
        }
        IPlayerSlot[] PlayerSlots
        {
            get;
        }
    }
}

