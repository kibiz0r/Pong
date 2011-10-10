using System;
using AllegroSharp;

namespace Pong
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var game = new PongGame(
                new PlayerSlot
                {
                    StartKey = Key.Num1,
                },
                new PlayerSlot
                {
                    StartKey = Key.Num0
                }
            );
            var input = new PongInput(new KeyboardInput());
            var display = new PongDisplay();
            while (true)
            {
                input.Apply(game);
                //game.Update(10);
                display.Render(game);
            }
        }
    }
}

