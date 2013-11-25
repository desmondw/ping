using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using XNAMenu;

using Ping.Graphics;
using Ping.Global;
using Ping.Sound;

namespace Ping.Screens
{
    class PausedScreen
    {
        Graphics_PauseScreen graphics = new Graphics_PauseScreen();

        public void LoadContent(ContentManager content)
        {
            graphics.PausedTexture = content.Load<Texture2D>(Constants.FILEPATH_GRAPHICS + "paused");
            graphics.Initialize();
        }

        public bool Update(Audio audio)
        {
            //handle state changes
            if (ButtonLock.PressedNotHeld(ButtonLock.PrevGamePad_P1.Buttons.Start, GamePad.GetState(PlayerIndex.One).Buttons.Start))
            {
                audio.PlaySound(Audio.SFX.MenuSelect);
                ScreenState.ActiveScreen = ScreenState.State.Game;
            }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(graphics.PausedTexture, graphics.PausedTexture_Position, Color.White);
        }
    }
}
