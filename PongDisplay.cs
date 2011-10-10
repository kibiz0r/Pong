using System;
using AllegroSharp;

namespace Pong
{
    public class PongDisplay
    {
        public PongDisplay()
        {
            Font = Ttf.LoadFont("Arial.ttf", 14, TtfFlags.None);
            if (Font == null)
            {
                throw new Exception("font failz");
            }
        }

        public Font Font { get; private set; }

        public void Render(IPongGame game)
        {
            Display.Clear(new Color(0, 0, 0));
            var slot1Text = game.IsPlayerSlotReady(game.PlayerSlots[0]) ? "Ready" : String.Format("Press {0} to Join", game.PlayerSlots[0].StartKey);
            Font.Draw(new Color(1, 0, 0), 100, 50, FontDrawFlags.AlignCentre, slot1Text);
            var slot2Text = game.IsPlayerSlotReady(game.PlayerSlots[1]) ? "Ready" : String.Format("Press {0} to Join", game.PlayerSlots[1].StartKey);
            Font.Draw(new Color(0, 0, 1), Display.Current.Width - 100, 50, FontDrawFlags.AlignCentre, slot2Text);
            Display.Flip();
        }
    }
}

