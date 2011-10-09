using System;
namespace Pong
{
    public class PongInput : IPongInput
    {
        public PongInput(IKeyboardInput keyboard)
        {
            this.keyboard = keyboard;
        }

        private IKeyboardInput keyboard;

        public void Apply(IPongGame game)
        {

        }
    }
}

