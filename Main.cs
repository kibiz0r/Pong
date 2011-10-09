using System;

namespace Pong
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var game = new PongGame(2);
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

