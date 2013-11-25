using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Graphics
{
    class Graphics_MainMenuScreen : Graphics_General
    {
        public Texture2D Background;

        //menu settings
        public const int MENU_WIDTH = 400;
        public const int MENU_HEIGHT = 400;
        public const int MENU_SPACING = 70;

        public Vector2 MenuPosition = new Vector2(SCREEN_WIDTH / 2 - MENU_WIDTH / 2, SCREEN_HEIGHT / 2);
    }
}
