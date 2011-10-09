using System;
using System.Collections.Generic;
using System.Linq;
namespace Pong
{
    public class PongGame : IPongGame
    {
        public PongGame(int numberOfPlayers)
        {
            players = Enumerable.Repeat<IPlayer>(null, numberOfPlayers).ToArray();
        }

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

        private IPlayer[] players = new IPlayer[0];
    }
}

