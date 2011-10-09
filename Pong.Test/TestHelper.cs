using System;
using NUnit.Framework;
namespace Pong.Test
{
    public class TestHelper
    {
        public IPongGame Game
        {
            get;
            set;
        }

        public void SetUp2PlayerPongGame()
        {
            Game = new PongGame();
        }
    }
}

