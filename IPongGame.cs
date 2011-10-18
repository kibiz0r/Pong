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
        bool Running
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
        int Width
        {
            get;
        }
        int Height
        {
            get;
        }
        IBall Ball
        {
            get;
        }
    }
}

