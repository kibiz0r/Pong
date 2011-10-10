using System;
using System.Collections.Generic;
using System.Linq;
namespace Pong
{
    public class PongGame : IPongGame
    {
        public PongGame(params IPlayerSlot[] playerSlots)
        {
            foreach (var playerSlot in playerSlots)
            {
                players.Add(playerSlot, null);
            }
            IsRunning = true;
        }

        public void Join(IPlayerSlot playerSlot)
        {
            players[playerSlot] = new Player();
        }

        public bool HasStarted
        {
            get { return players.Values.All(player => player != null); }
        }

        public bool IsRunning
        {
            get;
            private set;
        }

        public bool IsPlayerSlotReady(IPlayerSlot playerSlot)
        {
            return players[playerSlot] != null;
        }

        public void Exit()
        {
            IsRunning = false;
        }

        public IPlayer[] Players
        {
            get { return players.Values.ToArray(); }
        }

        public IPlayerSlot[] PlayerSlots
        {
            get { return players.Keys.ToArray(); }
        }

        private Dictionary<IPlayerSlot, IPlayer> players = new Dictionary<IPlayerSlot, IPlayer>();
    }
}

