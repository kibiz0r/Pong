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

        public static void AllegroMain()
        {
            InitializeAllegro();

            var bigBang = new BigBang();
            var game = bigBang.Get<IPongGame>();
            var display = bigBang.Get<IPongDisplay>();
            var input = bigBang.Get<IPongInput>();

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
            return new PongGame(null,
                new PlayerInitializer(
                    new PaddleFactory()
                ),
                new PlayerFactory(),
                new BallFactory(),
                new RandomBallInitializer()
                )
            {
                Width = Display.Current.Width,
                Height = Display.Current.Height,
                PlayerSlots = new IPlayerSlot[] {
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
                }
            };
        }

        public static IPongDisplay CreateDisplay()
        {
            return new PongDisplay(
                new ScreenRenderer(),
                new PlayerSlotRenderer(
                    new FontRenderer
                    {
                        Font = Content.Arial
                    }
                ),
                new BallRenderer(),
                new PaddleRenderer()
            );
        }

        public static IPongInput CreateInput()
        {
            return new PongInput(
                new KeyboardInput()
            );
        }
    }
}

