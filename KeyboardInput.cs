using System;
using AllegroSharp;
namespace Pong
{
    public class KeyboardInput : IKeyboardInput
    {
        private KeyboardState keyboardState = new KeyboardState();

        public KeyboardInput()
        {
            if (!Keyboard.Install())
            {
                throw new Exception("keyboard failz");
            }
        }

        public void Poll()
        {
            Keyboard.GetState(ref keyboardState);
        }

        public bool IsPressed(Key key)
        {
            return keyboardState.KeyDown(key);
        }
    }
}

