using System;
using NUnit.Framework;
using Moq;

namespace Pong.Test
{
    [TestFixture]
    public class PongGameTest : TestHelper
    {
        #region Constructor
        [Test]
        public void Constructor_allocates_players_list()
        {
            Game = new PongGame(5);
            Assert.That(Game.Players, Has.Length.EqualTo(5));
            Assert.That(Game.Players, Has.All.Null);
        }
        #endregion

        #region Join
        [Test]
        public void Join_adds_player_to_players_list()
        {
            SetUp2PlayerPongGame();
            var player1 = new Player();
            var player2 = new Player();
            Game.Join(player1);
            Game.Join(player2);
            Assert.That(Game.Players, Is.EqualTo(new Player[] { player1, player2 }));
        }

        [Test]
        public void Join_starts_game_when_last_player_joins()
        {
            SetUp2PlayerPongGame();
            var player1 = new Player();
            var player2 = new Player();
            Game.Join(player1);
            Game.Join(player2);
            Assert.That(Game.HasStarted);
        }
        #endregion
    }
}

