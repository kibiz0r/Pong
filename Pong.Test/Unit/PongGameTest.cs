using System;
using NUnit.Framework;
using Moq;
using System.Linq;

namespace Pong.Test
{
    [TestFixture]
    public class PongGameTest : TestHelper
    {
        public IPongGame Game
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            Game = Create2PlayerPongGame();
        }
        #region Constructor
        [Test]
        public void Constructor_allocates_players_list()
        {
            Game = new PongGame
            {
                PlayerSlots = new IPlayerSlot[] {
                    new PlayerSlot(),
                    new PlayerSlot(),
                    new PlayerSlot(),
                    new PlayerSlot(),
                    new PlayerSlot()
                }
            };
            Assert.That(Game.Players, Has.Length.EqualTo(5));
            Assert.That(Game.Players, Has.All.Null);
        }
        #endregion

        #region Join
        [Test]
        public void Join_adds_player_to_players_list()
        {
            Game.Join(Game.PlayerSlots[0]);
            Game.Join(Game.PlayerSlots[1]);
            Assert.That(Game.Players, Has.Length.EqualTo(2));
            Assert.That(Game.Players, Has.All.InstanceOf<IPlayer>());
        }

        [Test]
        public void Join_starts_game_when_last_player_joins()
        {
            Game.Join(Game.PlayerSlots[0]);
            Game.Join(Game.PlayerSlots[1]);
            Assert.That(Game.HasStarted);
        }

        [Test]
        public void Join_causes_a_player_slot_to_become_ready()
        {
            Assert.False(Game.PlayerSlots[0].IsReady);
            Assert.False(Game.PlayerSlots[1].IsReady);
            Game.Join(Game.PlayerSlots[1]);
            Assert.That(Game.PlayerSlots[1].IsReady);
            Game.Join(Game.PlayerSlots[0]);
            Assert.That(Game.PlayerSlots[0].IsReady);
        }
        #endregion

        #region Exit
        [Test]
        public void Exit_causes_game_to_stop_running()
        {
            Assert.That(Game.IsRunning);
            Game.Exit();
            Assert.False(Game.IsRunning);
        }
        #endregion
    }
}

