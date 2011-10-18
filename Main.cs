using System;
using AllegroSharp;
using Ninject;

namespace Pong
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Allegro.RunMain(AllegroMain);
        }

        public static BigBang BigBang;

        public static void AllegroMain()
        {
            InitializeAllegro();

            BigBang = new BigBang();
            var game = CreateGame();
            var display = CreateDisplay();
            var input = CreateInput();

            while (game.Running)
            {
                input.Apply(game);
                //game.Update(10);
                display.Render(game);
            }
        }

        public static void InitializeAllegro()
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
            if (!Primitives.Init())
            {
                throw new Exception("primitives failz");
            }
            Display.Create(800, 600);
        }

        public static IPongGame CreateGame()
        {
            var game = BigBang.Get<PongGame>();
            game.Width = Display.Current.Width;
            game.Height = Display.Current.Height;
            game.PlayerSlots = new IPlayerSlot[] {
                new PlayerSlot
                {
                    Color = new Color(1, 0, 0),
                    JoinReadyPosition = new Point(100, 50),
                    JoinReadyFontDrawFlags = FontDrawFlags.AlignLeft,
                    SpawnPosition = new Point(50, Display.Current.Height / 2),
                    StartKey = Key.Num1,
                },
                new PlayerSlot
                {
                    Color = new Color(0, 0, 1),
                    JoinReadyPosition = new Point(Display.Current.Width - 100, 50),
                    JoinReadyFontDrawFlags = FontDrawFlags.AlignRight,
                    SpawnPosition = new Point(Display.Current.Width - 50, Display.Current.Height / 2),
                    StartKey = Key.Num0
                }
            };
            return game;
        }

        public static IPongDisplay CreateDisplay()
        {
            return BigBang.Get<IPongDisplay>();
        }

        public static IPongInput CreateInput()
        {
            return BigBang.Get<IPongInput>();
        }
    }
}

