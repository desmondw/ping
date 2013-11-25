using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Graphics
{
    class Graphics_GameScreen : Graphics_General
    {
        public const int GAME_AREA_WIDTH = 720;
        public const int GAME_AREA_HEIGHT = 720;
        public const int PLAY_AREA_WIDTH = 600;
        public const int PLAY_AREA_HEIGHT = 600;

        public const int PADDLE_TEXTURE_LENGTH_LONG = 128;
        public const int PADDLE_TEXTURE_LENGTH_SHORT = 128;
        public const int BALL_TEXTURE_SIZE = 16;

        public Texture2D Background_GameArea;

        public Vector2 GameAreaPosition;
        public Vector2 PlayAreaPosition;
        public Vector2 PlayAreaCenter;

        public Graphics_GameScreen()
        {
            GameAreaPosition = new Vector2((Graphics_General.SCREEN_WIDTH - GAME_AREA_WIDTH) / 2, 0);
            PlayAreaPosition = new Vector2((SCREEN_WIDTH - PLAY_AREA_WIDTH) / 2, (SCREEN_HEIGHT - PLAY_AREA_HEIGHT) / 2);
            PlayAreaCenter = new Vector2(PlayAreaPosition.X + PLAY_AREA_WIDTH / 2, PlayAreaPosition.Y + PLAY_AREA_HEIGHT / 2);
        }
    }
}
