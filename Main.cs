using System;
using AllegroSharp;

namespace Pong
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Allegro.RunMain(AllegroMain);
        }

        public static void AllegroMain()
        {
            if (!Allegro.InstallSystem())
            {
                throw new Exception("allegro failz");
            }
            if (!Image.Init())
            {
                throw new Exception("image failz");
            }
            Font.Init();
            if (!Ttf.Init())
            {
                throw new Exception("ttf failz");
            }
            Display.Create(800, 600);
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
            var display = new PongDisplay();
            var input = new PongInput(new KeyboardInput());
            while (game.IsRunning)
            {
                input.Apply(game);
                //game.Update(10);
                display.Render(game);
            }
        }
    }
}

