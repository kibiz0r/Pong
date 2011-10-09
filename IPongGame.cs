using System;
using System.Collections.Generic;
namespace Pong
{
    public interface IPongGame
    {
        void Join(IPlayer player);
        bool HasStarted
        {
            get;
        }
        IEnumerable<IPlayer> Players { get; }
    }
}

