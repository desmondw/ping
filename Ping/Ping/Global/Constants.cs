using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Global
{
    public static class Constants
    {
        public const float DEGREE_MULTIPLIER = MathHelper.Pi / 180;

        public const int PADDLE_LENGTH_LONG = 128;
        public const int PADDLE_LENGTH_SHORT = 16;
        public const int BALL_SIZE = 16;

        public const string FILEPATH_GRAPHICS = "gfx/";
        public const string FILEPATH_BACKGROUNDS = FILEPATH_GRAPHICS + "bg/";
        public const string FILEPATH_MUSIC = "mus/";
        public const string FILEPATH_SOUND = "sfx/";
        public const string FILEPATH_NORMAL_SOUND = FILEPATH_SOUND + "normal/";
        public const string FILEPATH_SILLY_SOUND = FILEPATH_SOUND + "silly/";
        public const string FILEPATH_SILLY_MALE = FILEPATH_SILLY_SOUND + "male/";
        public const string FILEPATH_SILLY_MALE_BALL = FILEPATH_SILLY_MALE + "ballBallCollision/";
        public const string FILEPATH_SILLY_MALE_PADDLE = FILEPATH_SILLY_MALE + "ballPaddleCollision/";
        public const string FILEPATH_SILLY_MALE_SPAWN = FILEPATH_SILLY_MALE + "ballSpawn/";
        public const string FILEPATH_SILLY_MALE_WALL = FILEPATH_SILLY_MALE + "ballWallCollision/";
    }
}
