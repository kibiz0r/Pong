using System;
using NUnit.Framework;
using Moq;

namespace Pong.Test
{
    [TestFixture]
    public class PongGameTest
    {
        public IPongGame Game
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            Game = new PongGame();
        }

        #region Join
        [Test]
        public void Join_adds_player_to_players_list()
        {
            var player1 = new Player();
            var player2 = new Player();
            Game.Join(player1);
            Game.Join(player2);
            Assert.That(Game.Players, Is.EqualTo(new Player[] { player1, player2 }));
        }
        #endregion
    }
}

