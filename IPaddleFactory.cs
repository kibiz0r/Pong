using System;
namespace Pong
{
    public interface IPaddleFactory
    {
        IPaddle Create(Point position);
    }
}

