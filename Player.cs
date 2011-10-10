using System;
using AllegroSharp;
namespace Pong
{
    public class Player : IPlayer
    {
        public IPaddle Paddle
        {
            get;
            set;
        }
        public IPlayerSlot Slot
        {
            get;
            set;
        }
    }
}

