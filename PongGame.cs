using System;
using System.Collections.Generic;
using System.Linq;
namespace Pong
{
    public class PongGame : IPongGame
    {
        public PongGame()
        {
            IsRunning = true;
        }

        public void Join(IPlayerSlot playerSlot)
        {
            playerSlot.Join(new Player());
        }

        public bool HasStarted
        {
            get { return PlayerSlots.All(p => p.IsReady); }
        }

        public bool IsRunning
        {
            get;
            private set;
        }

        public void Exit()
        {
            IsRunning = false;
        }

        public IPlayer[] Players
        {
            get { return PlayerSlots.Select(p => p.Player).ToArray(); }
        }

        public IPlayerSlot[] PlayerSlots
        {
            get { return playerSlots; }
            set { playerSlots = value; }
        }

        private IPlayerSlot[] playerSlots = new IPlayerSlot[0];
    }
}

