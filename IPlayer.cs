using System;
using AllegroSharp;
namespace Pong
{
    public interface IPlayer
    {
        IPaddle Paddle
        {
            get;
            set;
        }
        IPlayerSlot Slot
        {
            get;
        }
    }
}

