using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Graphics
{
    class Graphics_PauseScreen : Graphics_General
    {
        public Texture2D PausedTexture;
        public Vector2 PausedTexture_Position;

        public void Initialize()
        {
            PausedTexture_Position.X = SCREEN_WIDTH / 2 - PausedTexture.Width / 2;
            PausedTexture_Position.Y = SCREEN_HEIGHT / 2 - PausedTexture.Height / 2;
        }
    }
}
