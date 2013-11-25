using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Ping.Global
{
    public static class ButtonLock
    {
        public static GamePadState PrevGamePad_P1;
        public static GamePadState PrevGamePad_P2;
        public static GamePadState PrevGamePad_P3;
        public static GamePadState PrevGamePad_P4;

        public static bool PressedNotHeld(ButtonState oldButtonState, ButtonState newButtonState)
        {
            if (newButtonState == ButtonState.Pressed && oldButtonState == ButtonState.Released)
                return true;
            else
                return false;
        }

        public static bool PressedNotHeld(float oldButtonState, float newButtonState)
        {
            if (newButtonState != 0 && oldButtonState == 0)
                return true;
            else
                return false;
        }

        public static bool PressedNotHeld(float oldButtonState, float newButtonState, bool positive)
        {
            if (positive && newButtonState > 0 && oldButtonState <= 0)
                return true;
            else if (!positive && newButtonState < 0 && oldButtonState >= 0)
                return true;
            else
                return false;
        }
    }
}

