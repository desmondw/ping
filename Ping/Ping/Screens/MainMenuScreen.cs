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
    class MainMenuScreen
    {
        Graphics_MainMenuScreen graphics = new Graphics.Graphics_MainMenuScreen();
        bool exitGame = false;

        Menu menu;

        public void LoadContent(ContentManager content)
        {
            //Load the background texture for the screen
            graphics.Background = content.Load<Texture2D>(Constants.FILEPATH_BACKGROUNDS + "MainMenuBG");

            //create the menu
            initializeMenu(content);
        }

        private void initializeMenu(ContentManager content)
        {
            menu = new Menu((int)graphics.MenuPosition.X, (int)graphics.MenuPosition.Y, Graphics_MainMenuScreen.MENU_WIDTH, Graphics_MainMenuScreen.MENU_HEIGHT, content.Load<SpriteFont>("Segoe UI Mono"));
            menu.ElementSpacing = Graphics_MainMenuScreen.MENU_SPACING;
            menu.ApplyChanges();

            //options list
            MenuList options = menu.CreateList();
            options.AddElement("Sound", toggleSound, Settings.SoundOn);
            options.AddElement("Music", toggleMusic, Settings.MusicOn);
            options.AddElement("Silly Mode", toggleSillyMode, Settings.SillyMode);
            options.AddElement("Back");

            //main list
            menu.List.AddElement("Play", gotoGameScreen);
            menu.List.AddElement("Options", options);
            menu.List.AddElement("Exit", exit);
        }

        #region Menu Actions
        private void toggleSound()
        {
            Settings.SoundOn = !Settings.SoundOn;
        }

        private void toggleMusic()
        {
            Settings.MusicOn = !Settings.MusicOn;
        }

        private void toggleSillyMode()
        {
            Settings.SillyMode = !Settings.SillyMode;
        }

        private void gotoTitleScreen()
        {
            ScreenState.ActiveScreen = ScreenState.State.Title;
        }

        private void gotoGameScreen()
        {
            //GameScreen.newGame();
            ScreenState.ActiveScreen = ScreenState.State.Game;
        }

        private void exit()
        {
            exitGame = true;
        }

        //dummy method
        private void doNothing()
        {

        }
        #endregion

        public bool Update(Audio audio)
        {
            audio.ToggleMusic();

            //menu interaction
            if (ButtonLock.PressedNotHeld(ButtonLock.PrevGamePad_P1.Buttons.A, GamePad.GetState(PlayerIndex.One).Buttons.A))
            {
                menu.ActiveList.ActivateActiveElement();
                audio.PlaySound(Audio.SFX.MenuSelect);
            }
            if (ButtonLock.PressedNotHeld(ButtonLock.PrevGamePad_P1.Buttons.B, GamePad.GetState(PlayerIndex.One).Buttons.B))
            {
                audio.PlaySound(Audio.SFX.MenuBack);

                if (!menu.ActiveList.ExitList())
                    gotoTitleScreen();
            }
            if (ButtonLock.PressedNotHeld(ButtonLock.PrevGamePad_P1.DPad.Up, GamePad.GetState(PlayerIndex.One).DPad.Up) || ButtonLock.PressedNotHeld(ButtonLock.PrevGamePad_P1.ThumbSticks.Left.Y, GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y, true))
            {
                menu.ActiveList.SetActiveElementPrev();
                audio.PlaySound(Audio.SFX.MenuMove);
            }
            if (ButtonLock.PressedNotHeld(ButtonLock.PrevGamePad_P1.DPad.Down, GamePad.GetState(PlayerIndex.One).DPad.Down) || ButtonLock.PressedNotHeld(ButtonLock.PrevGamePad_P1.ThumbSticks.Left.Y, GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y, false))
            {
                menu.ActiveList.SetActiveElementNext();
                audio.PlaySound(Audio.SFX.MenuMove);
            }

            return exitGame;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(graphics.Background, Vector2.Zero, Color.White);
            menu.Draw(spriteBatch);
        }
    }
}
