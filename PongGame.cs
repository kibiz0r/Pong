using System;
using System.Collections.Generic;
using System.Linq;
namespace Pong
{
    public class PongGame : IPongGame
    {
        public PongGame(IGameInitializer gameInitializer, IPlayerInitializer playerInitializer,
            IPlayerFactory playerFactory, IBallFactory ballFactory, IBallInitializer ballInitializer)
        {
            this.gameInitializer = gameInitializer;
            this.playerInitializer = playerInitializer;
            this.playerFactory = playerFactory;
            this.ballFactory = ballFactory;
            this.ballInitializer = ballInitializer;
            Running = true;
        }

        private readonly IGameInitializer gameInitializer;
        private readonly IPlayerInitializer playerInitializer;
        private readonly IPlayerFactory playerFactory;
        private readonly IBallFactory ballFactory;
        private readonly IBallInitializer ballInitializer;

        public void Join(IPlayerSlot playerSlot)
        {
            if (playerSlot.Ready)
            {
                return;
            }
            var wasStarted = HasStarted;
            playerSlot.Join(playerFactory.Create(playerSlot));
            if (!wasStarted && HasStarted)
            {
                foreach (var player in Players)
                {
                    playerInitializer.Initialize(player);
                }
                Ball = ballFactory.Create(new Point(Width / 2, Height / 2));
                ballInitializer.Initialize(Ball);
            }
        }

        public bool HasStarted
        {
            get { return PlayerSlots.All(p => p.Ready); }
        }

        public bool Running
        {
            get;
            private set;
        }

        public void Exit()
        {
            Running = false;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public IBall Ball
        {
            get;
            private set;
        }

        public IPlayer[] Players
        {
            get { return PlayerSlots.Select(p => p.Player).ToArray(); }
        }

        public IPlayerSlot[] PlayerSlots
        {
            get { return playerSlots; }
            set { playerSlots = value; }
        }

        private IPlayerSlot[] playerSlots = new IPlayerSlot[0];

        public IPlayer Player1
        {
            get { return Players[0]; }
        }
        public IPlayer Player2
        {
            get { return Players[1]; }
        }
        public IPlayerSlot PlayerSlot1
        {
            get { return PlayerSlots[0]; }
        }
        public IPlayerSlot PlayerSlot2
        {
            get { return PlayerSlots[1]; }
        }
    }
}

