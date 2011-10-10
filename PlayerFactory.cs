using System;
namespace Pong
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer Create(IPlayerSlot slot)
        {
            return new Player
            {
                Slot = slot
            };
        }
    }
}

