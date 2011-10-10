using System;
using AllegroSharp;
namespace Pong
{
    public class PlayerSlot : IPlayerSlot
    {
        public Key StartKey
        {
            get;
            set;
        }
        public Color Color
        {
            get;
            set;
        }
        public Point JoinReadyPosition
        {
            get;
            set;
        }
        public FontDrawFlags JoinReadyFontDrawFlags
        {
            get;
            set;
        }
        public bool IsReady
        {
            get { return Player != null; }
        }
        public IPlayer Player
        {
            get;
            private set;
        }
        public string ReadyText
        {
            get { return "Ready"; }
        }
        public string JoinText
        {
            get { return String.Format("Press {0} to Join", StartKey); }
        }
        public void Join(IPlayer player)
        {
            Player = player;
        }
    }
}

