using System;
using NUnit.Framework;
using Moq;
using System.Linq;

namespace Pong.Test
{
    [TestFixture]
    public class PongGameTest : TestHelper
    {
        public PongGame _subject;
        public PongGame Subject
        {
            get
            {
                return _subject = _subject ?? new PongGame
                {
                    GameInitializer = GameInitializer.Object,
                    BallFactory = BallFactory.Object,
                    BallInitializer = BallInitializer.Object,
                    PlayerFactory = PlayerFactory.Object,
                    PlayerInitializer = PlayerInitializer.Object
                };
            }
        }
        #region Dependencies
        public Mock<IGameInitializer> _GameInitializer;
        public Mock<IGameInitializer> GameInitializer
        {
            get { return _GameInitializer = _GameInitializer ?? Mock<IGameInitializer>(); }
        }
        public Mock<IBallFactory> _ballFactory;
        public Mock<IBallFactory> BallFactory
        {
            get
            {
                return _ballFactory = _ballFactory ?? Mock<IBallFactory>();
            }
        }
        public Mock<IBallInitializer> _ballInitializer;
        public Mock<IBallInitializer> BallInitializer
        {
            get { return _ballInitializer = _ballInitializer ?? Mock<IBallInitializer>(); }
        }
        public Mock<IPlayerFactory> _playerFactory;
        public Mock<IPlayerFactory> PlayerFactory
        {
            get { return _playerFactory = _playerFactory ?? Mock<IPlayerFactory>(); }
        }
        public Mock<IPlayerInitializer> _PlayerInitializer;
        public Mock<IPlayerInitializer> PlayerInitializer
        {
            get { return _PlayerInitializer = _PlayerInitializer ?? Mock<IPlayerInitializer>(); }
        }
        #endregion
        /*public Mock<IPlayer> _Player1;
        public Mock<IPlayer> Player1
        {
            get { return _Player1 = _Player1 ?? Mock<IPlayer>(); }
        }
        public Mock<IPlayer> _Player2;
        public Mock<IPlayer> Player2
        {
            get { return _Player2 = _Player2 ?? Mock<IPlayer>(); }
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
        public IBall Ball
        {
            get;
            set;
        }*/

        [SetUp]
        public void SetUp()
        {
            /*PlayerSlot1 = new PlayerSlot
            {
                SpawnPosition = Player1SpawnPosition
            };
            PlayerSlot2 = new PlayerSlot
            {
                SpawnPosition = Player2SpawnPosition
            };
            Ball = Mock<IBall>().Object;
            BallFactory.Setup(b => b.Create(It.IsAny<Point>())).Returns(Ball);
            PlayerFactory.Setup(p => p.Create(PlayerSlot1)).Returns(Player1.Object);
            PlayerFactory.Setup(p => p.Create(PlayerSlot2)).Returns(Player2.Object);
            Game = new PongGame
            {
                PlayerInitializer = PlayerInitializer.Object,
                PlayerFactory = PlayerFactory.Object,
                BallFactory = BallFactory.Object,
                BallInitializer = BallInitializer.Object,
                PlayerSlots = new IPlayerSlot[] { PlayerSlot1, PlayerSlot2 },
                Width = 80,
                Height = 140
            };*/
        }

        public static readonly Point MiddleOfField = new Point(40, 70);

        [TestFixture]
        public class PongGame_JoinTest : PongGameTest
        {
            public IPlayerSlot PlayerSlot1;
            public IPlayerSlot PlayerSlot2;
            public Mock<IPlayer> _Player1;
            public Mock<IPlayer> Player1
            {
                get
                {
                    return _Player1 = _Player1 ?? Mock<IPlayer>();
                }
            }
            public Mock<IPlayer> _Player2;
            public Mock<IPlayer> Player2
            {
                get
                {
                    return _Player2 = _Player2 ?? Mock<IPlayer>();
                }
            }
            [Test]
            public void Join_adds_player_to_players_list()
            {
                Subject.Join(PlayerSlot1);
                Subject.Join(PlayerSlot2);
                Assert.That(Subject.Players, Is.EqualTo(new IPlayer[] { Player1.Object, Player2.Object }));
            }
    
            [Test]
            public void Starts_game_when_last_player_joins()
            {
                GameInitializer.Mocks(g => g.Initialize(Subject));
                Subject.Join(PlayerSlot1);
                Subject.Join(PlayerSlot2);
            }
    
            [Test]
            public void Join_causes_a_player_slot_to_become_ready()
            {
                Assert.False(Subject.PlayerSlot1.Ready);
                Assert.False(Subject.PlayerSlot2.Ready);
                Subject.Join(Subject.PlayerSlot1);
                Assert.That(Subject.PlayerSlot2.Ready);
                Subject.Join(Subject.PlayerSlot1);
                Assert.That(Subject.PlayerSlot1.Ready);
            }
    
            [Test]
            public void Ignores_joining_occupied_slot()
            {
                var playerSlot = Mock<IPlayerSlot>();
                playerSlot.Mocks(p => p.Ready).Returns(true);
                Subject.Join(playerSlot.Object);
            }
        }

        #region Exit
        [Test]
        public void Exit_causes_game_to_stop_running()
        {
            Assert.That(Subject.Running);
            Subject.Exit();
            Assert.False(Subject.Running);
        }
        #endregion
    }
}

