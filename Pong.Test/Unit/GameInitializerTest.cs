using System;
using NUnit.Framework;
using Moq;

namespace Pong.Test
{
    public class GameInitializerTest : TestHelper
    {
        public GameInitializer _subject;
        public GameInitializer Subject
        {
            get
            {
                return _subject = _subject ?? new GameInitializer
                {
                    PlayerInitializer = PlayerInitializer.Object,
                    BallFactory = BallFactory.Object,
                    BallInitializer = BallInitializer.Object
                };
            }
        }
        public Mock<IPlayerInitializer> _PlayerInitializer;
        public Mock<IPlayerInitializer> PlayerInitializer
        {
            get
            {
                return _PlayerInitializer = _PlayerInitializer ?? Mock<IPlayerInitializer>();
            }
        }
        public Mock<IBallFactory> _BallFactory;
        public Mock<IBallFactory> BallFactory
        {
            get { return _BallFactory = _BallFactory ?? Mock<IBallFactory>(); }
        }
        public Mock<IBallInitializer> _BallInitializer;
        public Mock<IBallInitializer> BallInitializer
        {
            get { return _BallInitializer = _BallInitializer ?? Mock<IBallInitializer>(); }
        }
        public Mock<IPongGame> _Game;
        public Mock<IPongGame> Game
        {
            get { return _Game = _Game ?? Mock<IPongGame>(); }
        }
        public Mock<IBall> _Ball;
        public Mock<IBall> Ball
        {
            get { return _Ball = _Ball ?? Mock<IBall>(); }
        }
        public static Point MiddleOfField = new Point(40, 70);
        [Test]
        public void Initialize_initializes_players()
        {
            var player1 = Dummy<IPlayer>();
            var player2 = Dummy<IPlayer>();
            Game.Stubs(g => g.Players).Returns(new IPlayer[] { player1, player2 });
            PlayerInitializer.Mocks(p => p.Initialize(player1));
            PlayerInitializer.Mocks(p => p.Initialize(player2));
            Subject.Initialize(Game.Object);
        }

        [Test]
        public void Initialize_creates_ball()
        {
            BallFactory.Mocks(b => b.Create(MiddleOfField)).Returns(Ball.Object);
            Subject.Initialize(Game.Object);
        }

        [Test]
        public void Initialize_initializes_ball()
        {
            BallInitializer.Mocks(b => b.Initialize(Ball.Object));
            Subject.Initialize(Game.Object);
        }
    }
}

