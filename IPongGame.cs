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
        bool IsRunning
        {
            get;
        }
        void Exit();
        IPlayer[] Players
        {
            get;
        }
        IPlayerSlot[] PlayerSlots
        {
            get;
        }
        bool IsPlayerSlotReady(IPlayerSlot playerSlot);
    }
}

