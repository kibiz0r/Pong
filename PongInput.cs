using System;
using AllegroSharp;
namespace Pong
{
    public class PongInput : IPongInput
    {
        public IKeyboardInput KeyboardInput;

        public void Apply(IPongGame game)
        {
            KeyboardInput.Poll();
            if (KeyboardInput.IsPressed(Key.Escape))
            {
                game.Exit();
            }
            foreach (var playerSlot in game.PlayerSlots)
            {
                if (KeyboardInput.IsPressed(playerSlot.StartKey))
                {
                    game.Join(playerSlot);
                }
            }
        }
    }
}

