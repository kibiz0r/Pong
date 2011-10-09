using System;
using System.Collections.Generic;
namespace Pong
{
    public class PongGame : IPongGame
    {
        public void Join(IPlayer player)
        {
            //
        }

        public bool HasStarted
        {
            get { return false; }
        }

        public IEnumerable<IPlayer> Players
        {
            get { return players; }
        }

        private List<IPlayer> players = new List<IPlayer>();
    }
}

