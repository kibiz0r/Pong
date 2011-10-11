using System;
using NUnit.Framework;

namespace Pong.Test
{
    public class FunctionalTestHelper : HighLevelTestHelper
    {
        public override IPongGame Game
        {
            get;
            set;
        }
        public override RiggedBallInitializer BallInitializer
        {
            get;
            set;
        }

        public const int Width = 300;
        public const int Height = 200;

        [SetUp]
        public void SetUp()
        {
            BallInitializer = new RiggedBallInitializer();
            var game = Create2PlayerPongGame();
            game.Width = Width;
            game.Height = Height;
            Game = game;
        }
    }
}

