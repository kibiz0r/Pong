using System;
using NUnit.Framework;
using Moq;
using System.Linq;

namespace Pong.Test
{
    [TestFixture]
    public class PongGameTest : TestHelper
    {
        #region Constructor
        [Test]
        public void Constructor_allocates_players_list()
        {
            Game = new PongGame(
                new PlayerSlot(),
                new PlayerSlot(),
                new PlayerSlot(),
                new PlayerSlot(),
                new PlayerSlot()
            );
            Assert.That(Game.Players, Has.Length.EqualTo(5));
            Assert.That(Game.Players, Has.All.Null);
        }
        #endregion

        #region Join
        [Test]
        public void Join_adds_player_to_players_list()
        {
            SetUp2PlayerPongGame();
            Game.Join(Game.PlayerSlots[0]);
            Game.Join(Game.PlayerSlots[1]);
            Assert.That(Game.Players, Has.Length.EqualTo(2));
            Assert.That(Game.Players, Has.All.InstanceOf<IPlayer>());
        }

        [Test]
        public void Join_starts_game_when_last_player_joins()
        {
            SetUp2PlayerPongGame();
            Game.Join(Game.PlayerSlots[0]);
            Game.Join(Game.PlayerSlots[1]);
            Assert.That(Game.HasStarted);
        }
        #endregion
    }
}

