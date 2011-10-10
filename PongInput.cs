using System;
namespace Pong
{
    public class PongInput : IPongInput
    {
        public PongInput(IKeyboardInput keyboard)
        {
            this.keyboard = keyboard;
        }

        private IKeyboardInput keyboard;

        public void Apply(IPongGame game)
        {
            foreach (var playerSlot in game.PlayerSlots)
            {
                if (keyboard.IsPressed(playerSlot.StartKey))
                {
                    game.Join(playerSlot);
                }
            }
        }
    }
}

