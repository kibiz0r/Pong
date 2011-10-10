using System;
using AllegroSharp;
namespace Pong
{
    public interface IKeyboardInput
    {
        void Poll();
        bool IsPressed(Key key);
    }
}

