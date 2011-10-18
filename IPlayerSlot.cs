using System;
using AllegroSharp;
namespace Pong
{
    public interface IPlayerSlot
    {
        Key StartKey
        {
            get;
        }
        Color Color
        {
            get;
        }
        Point JoinReadyPosition
        {
            get;
        }
        FontDrawFlags JoinReadyFontDrawFlags
        {
            get;
        }
        string ReadyText
        {
            get;
        }
        bool Ready
        {
            get;
        }
        string JoinText
        {
            get;
        }
        void Join(IPlayer player);
        IPlayer Player
        {
            get;
        }
        Point SpawnPosition
        {
            get;
        }
    }
}

