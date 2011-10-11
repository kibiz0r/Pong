using System;
namespace Pong
{
    public interface IBall
    {
        Point Position
        {
            get;
        }
        Point Velocity
        {
            get;
            set;
        }
    }
}

