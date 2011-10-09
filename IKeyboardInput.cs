using System;
using AllegroSharp;
namespace Pong
{
    public interface IKeyboardInput
    {
        bool IsPressed(Key key);
    }
}

