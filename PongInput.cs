using System;
using AllegroSharp;
namespace Pong
{
    public class PongInput : IPongInput
    {
        public PongInput(IKeyboardInput keyboardInput)
        {
            this.keyboardInput = keyboardInput;
        }
        private readonly IKeyboardInput keyboardInput;

        public void Apply(IPongGame game)
        {
            keyboardInput.Poll();
            if (keyboardInput.IsPressed(Key.Escape))
            {
                game.Exit();
            }
            foreach (var playerSlot in game.PlayerSlots)
            {
                if (keyboardInput.IsPressed(playerSlot.StartKey))
                {
                    game.Join(playerSlot);
                }
            }
        }
    }
}

