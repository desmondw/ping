using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Global
{
    public static class Settings
    {
        public static bool SillyMode = false;
        public static bool SoundOn = true;
        public static bool MusicOn = true;

        public static bool PaddleInertiaActive = true;
        public static bool BallInertiaActive = false;
        public static float EnergyConservation_BallPaddle = 3; //[PERCENTAGE] amount of speed to transfer from paddle to ball in a collision
        public static float EnergyConservation_BallBall = 1; //[PERCENTAGE] amount of speed to transfer from ball to ball in a collision
    }
}
