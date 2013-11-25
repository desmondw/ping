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
    class TitleScreen
    {
        Graphics_TitleScreen graphics = new Graphics_TitleScreen();

        public void LoadContent(ContentManager content)
        {
            //Load the background texture for the screen
            graphics.Background = content.Load<Texture2D>(Constants.FILEPATH_BACKGROUNDS + "TitleBG");
        }

        public bool Update(Audio audio)
        {
            //handle state changes
            if (ButtonLock.PressedNotHeld(ButtonLock.PrevGamePad_P1.Buttons.A, GamePad.GetState(PlayerIndex.One).Buttons.A) || ButtonLock.PressedNotHeld(ButtonLock.PrevGamePad_P1.Buttons.Start, GamePad.GetState(PlayerIndex.One).Buttons.Start))
            {
                audio.PlaySound(Audio.SFX.MenuSelect);
                ScreenState.ActiveScreen = ScreenState.State.MainMenu;
            }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(graphics.Background, Vector2.Zero, Color.White);
        }
    }
}
