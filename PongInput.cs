using System;
using AllegroSharp;
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
            keyboard.Poll();
            if (keyboard.IsPressed(Key.Escape))
            {
                game.Exit();
            }
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

