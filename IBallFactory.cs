using System;
namespace Pong
{
    public interface IBallFactory
    {
        IBall Create(Point position);
    }
}

