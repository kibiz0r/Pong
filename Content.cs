using System;
using AllegroSharp;

namespace Pong
{
    /// <summary>
    /// Any expression that makes a reference to this type can potentially throw an exception by being the first to
    /// trigger the static initializers. This is only safe to do /after/ Allegro has been fully initialized.
    /// </summary>
    public static class Content
    {
        public static Font Arial = LoadFont("Arial.ttf", 14, TtfFlags.None);

        public static Font LoadFont(string filename, int size, TtfFlags flags)
        {
            var font = Ttf.LoadFont(filename, size, flags);
            if (font == null)
            {
                throw new Exception(String.Format("LoadFont({0}, {1}, {2}) Failed", filename, size, flags));
            }
            return font;
        }
    }
}

