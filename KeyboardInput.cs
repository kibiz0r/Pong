using System;
using AllegroSharp;
namespace Pong
{
    public class KeyboardInput : IKeyboardInput
    {
        public bool IsPressed(Key key)
        {
            return false;
        }
    }
}

