using System;
namespace Pong
{
    public class Ball : IBall
    {
        public Point Position
        {
            get;
            set;
        }
        public Point Velocity
        {
            get;
            set;
        }
    }
}

