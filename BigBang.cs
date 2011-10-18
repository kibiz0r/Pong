using System;
using Ninject;
namespace Pong
{
    public class BigBang : StandardKernel
    {
        public BigBang()
        {
            Bind<IPlayerFactory>().To<PlayerFactory>();
            Bind<IBallFactory>().To<BallFactory>();
            Bind<IBallInitializer>().To<RandomBallInitializer>();
            Bind<IGameInitializer>().To<GameInitializer>();
            Bind<IPlayerInitializer>().To<PlayerInitializer>();
            Bind<IPongGame>().To<PongGame>();
            Bind<IPaddleFactory>().To<PaddleFactory>();
            Bind<IScreenRenderer>().To<ScreenRenderer>();
            Bind<IPongDisplay>().To<PongDisplay>();
            Bind<IPlayerSlotRenderer>().To<PlayerSlotRenderer>();
            Bind<IFontRenderer>().ToMethod(c => new FontRenderer { Font = Content.Arial });
            Bind<IBallRenderer>().To<BallRenderer>();
            Bind<IPaddleRenderer>().To<PaddleRenderer>();
            Bind<IPongInput>().To<PongInput>();
            Bind<IKeyboardInput>().To<KeyboardInput>();
        }
    }
}

