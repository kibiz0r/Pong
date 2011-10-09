using System;
namespace Pong
{
    public interface IPongInput
    {
        void Apply(IPongGame game);
    }
}

