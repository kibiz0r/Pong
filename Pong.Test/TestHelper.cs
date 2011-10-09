using System;
using NUnit.Framework;
namespace Pong.Test
{
    public class TestHelper
    {
        public virtual IPongGame Game
        {
            get;
            set;
        }

        public void SetUp2PlayerPongGame()
        {
            Game = new PongGame(2);
        }
    }
}

