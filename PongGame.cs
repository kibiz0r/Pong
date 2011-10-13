using System;
using System.Collections.Generic;
using System.Linq;
namespace Pong
{
    public class PongGame : IPongGame
    {
        public PongGame()
        {
            IsRunning = true;
        }

        public IGameInitializer GameInitializer
        {
            get;
            set;
        }

        public IPlayerInitializer PlayerInitializer
        {
            get;
            set;
        }

        public IPlayerFactory PlayerFactory
        {
            get;
            set;
        }

        public IBallFactory BallFactory
        {
            get;
            set;
        }

        public IBallInitializer BallInitializer
        {
            get;
            set;
        }

        public void Join(IPlayerSlot playerSlot)
        {
            if (playerSlot.IsReady)
            {
                return;
            }
            var wasStarted = HasStarted;
            playerSlot.Join(PlayerFactory.Create(playerSlot));
            if (!wasStarted && HasStarted)
            {
                foreach (var player in Players)
                {
                    PlayerInitializer.Initialize(player);
                }
                Ball = BallFactory.Create(new Point(Width / 2, Height / 2));
                BallInitializer.Initialize(Ball);
            }
        }

        public bool HasStarted
        {
            get { return PlayerSlots.All(p => p.IsReady); }
        }

        public bool IsRunning
        {
            get;
            private set;
        }

        public void Exit()
        {
            IsRunning = false;
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

