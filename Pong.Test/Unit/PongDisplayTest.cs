using System;
using NUnit.Framework;
using Moq;

namespace Pong.Test
{
    [TestFixture]
    public class PongDisplayTest : TestHelper
    {
        public Mock<IRenderer> Renderer
        {
            get;
            set;
        }
        public Mock<IPongGame> Game
        {
            get;
            set;
        }
        public IPongDisplay Display
        {
            get;
            set;
        }
        public Mock<IPlayerSlotRenderer> PlayerSlotRenderer
        {
            get;
            set;
        }
        public Mock<IBallRenderer> BallRenderer
        {
            get;
            set;
        }
        public Mock<IPaddleRenderer> PaddleRenderer
        {
            get;
            set;
        }
        public Mock<IBall> Ball
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            Renderer = Stub<IRenderer>();
            Game = Stub<IPongGame>();
            PlayerSlotRenderer = Mock<IPlayerSlotRenderer>();
            BallRenderer = Stub<IBallRenderer>();
            PaddleRenderer = Mock<IPaddleRenderer>();
            Ball = Mock<IBall>();
            Game.Setup(g => g.Ball).Returns(Ball.Object);
            Display = new PongDisplay(Renderer.Object, PlayerSlotRenderer.Object, BallRenderer.Object, PaddleRenderer.Object);
        }

        [Test]
        public void Render_clears_display()
        {
            Renderer.Setup(r => r.Clear()).Verifiable();
            Display.Render(Game.Object);
        }

        [Test]
        public void Render_flips_display()
        {
            Renderer.Setup(r => r.Flip()).Verifiable();
            Display.Render(Game.Object);
        }

        [Test]
        public void Render_renders_player_slots()
        {
            var playerSlot1 = Mock<IPlayerSlot>();
            var playerSlot2 = Mock<IPlayerSlot>();
            Game.Setup(g => g.PlayerSlots).Returns(new IPlayerSlot[] { playerSlot1.Object, playerSlot2.Object });
            PlayerSlotRenderer.Setup(s => s.Render(playerSlot1.Object));
            PlayerSlotRenderer.Setup(s => s.Render(playerSlot2.Object));
            Display.Render(Game.Object);
        }

        [Test]
        public void Render_renders_ball_if_game_has_started()
        {
            Game.Setup(g => g.HasStarted).Returns(true);
            BallRenderer.Setup(b => b.Render(Ball.Object)).Verifiable();
            Display.Render(Game.Object);
        }

        [Test]
        public void Render_doesnt_render_ball_if_game_hasnt_started()
        {
            Game.Setup(g => g.HasStarted).Returns(false);
            BallRenderer.Setup(b => b.Render(Ball.Object)).Throws<Exception>();
            Display.Render(Game.Object);
        }

        [Test]
        public void Render_renders_paddles_if_game_has_started()
        {
            var paddle1 = Mock<IPaddle>();
            var paddle2 = Mock<IPaddle>();
            var player1 = Mock<IPlayer>();
            var player2 = Mock<IPlayer>();

            player1.Setup(p => p.Paddle).Returns(paddle1.Object);
            player2.Setup(p => p.Paddle).Returns(paddle2.Object);
            Game.Setup(g => g.HasStarted).Returns(true);
            Game.Setup(g => g.Players).Returns(new IPlayer[] { player1.Object, player2.Object });

            PaddleRenderer.Setup(p => p.Render(paddle1.Object));
            PaddleRenderer.Setup(p => p.Render(paddle2.Object));

            Display.Render(Game.Object);
        }
    }
}

