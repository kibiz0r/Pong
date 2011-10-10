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
        public Mock<IPlayerInitializer> PlayerInitializer
        {
            get;
            set;
        }
        public Mock<IPlayerFactory> PlayerFactory
        {
            get;
            set;
        }
        public Mock<IPlayer> Player1
        {
            get;
            set;
        }
        public Mock<IPlayer> Player2
        {
            get;
            set;
        }
        public IPlayerSlot PlayerSlot1
        {
            get;
            set;
        }
        public IPlayerSlot PlayerSlot2
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            PlayerInitializer = Stub<IPlayerInitializer>();
            Player1 = Stub<IPlayer>();
            Player2 = Stub<IPlayer>();
            PlayerSlot1 = new PlayerSlot
            {
                SpawnPosition = Player1SpawnPosition
            };
            PlayerSlot2 = new PlayerSlot
            {
                SpawnPosition = Player2SpawnPosition
            };
            PlayerFactory = Stub<IPlayerFactory>();
            PlayerFactory.Setup(p => p.Create(PlayerSlot1)).Returns(Player1.Object);
            PlayerFactory.Setup(p => p.Create(PlayerSlot2)).Returns(Player2.Object);
            Game = new PongGame
            {
                PlayerInitializer = PlayerInitializer.Object,
                PlayerFactory = PlayerFactory.Object,
                PlayerSlots = new IPlayerSlot[] { PlayerSlot1, PlayerSlot2 }
            };
        }

        #region Join
        [Test]
        public void Join_adds_player_to_players_list()
        {
            Game.Join(Game.PlayerSlots[0]);
            Game.Join(Game.PlayerSlots[1]);
            Assert.That(Game.Players, Is.EqualTo(new IPlayer[] { Player1.Object, Player2.Object }));
        }

        [Test]
        public void Starts_game_when_last_player_joins()
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

        [Test]
        public void Ignores_joining_occupied_slot()
        {
            var playerSlot = Mock<IPlayerSlot>();
            playerSlot.Setup(p => p.IsReady).Returns(true);
            Game.Join(playerSlot.Object);
        }
        #endregion

        #region Initialization
        [Test]
        public void Game_initializes_players()
        {
            PlayerInitializer.Setup(p => p.Initialize(Player1.Object)).Verifiable();
            PlayerInitializer.Setup(p => p.Initialize(Player2.Object)).Verifiable();
            Start(Game);
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

