using System;
namespace Pong
{
    public struct Point
    {
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public readonly float X;
        public readonly float Y;

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }
    }
}

