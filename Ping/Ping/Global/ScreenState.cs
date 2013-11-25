using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Ping.Global
{
    public static class ScreenState
    {
        public enum State
        {
            Title,
            MainMenu,
            Game,
            Paused
        }

        //the active screen
        public static State ActiveScreen;
    }
}
