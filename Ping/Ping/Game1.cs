using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Ping.Graphics;
using Ping.Global;
using Ping.Screens;
using Ping.Sound;

namespace Ping
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //required
        GraphicsDeviceManager Graphics;
        SpriteBatch SpriteBatch;

        //sound
        Audio Audio;

        //the screens
        TitleScreen TitleScreen;
        MainMenuScreen MainMenuScreen;
        GameScreen GameScreen;
        PausedScreen PausedScreen;

        bool exitGame = false;

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Graphics.PreferredBackBufferWidth = Graphics_General.SCREEN_WIDTH;
            Graphics.PreferredBackBufferHeight = Graphics_General.SCREEN_HEIGHT;
            Graphics.ApplyChanges();

            //Set the active screen
            ScreenState.ActiveScreen = ScreenState.State.Title;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            //sound
            Audio = new Audio(Content);
            Audio.ToggleMusic();

            //load screens
            TitleScreen = new TitleScreen();
            MainMenuScreen = new MainMenuScreen();
            GameScreen = new GameScreen();
            PausedScreen = new PausedScreen();

            TitleScreen.LoadContent(Content);
            MainMenuScreen.LoadContent(Content);
            GameScreen.Initialize(GraphicsDevice.Viewport.TitleSafeArea.Height, GraphicsDevice.Viewport.Height, GraphicsDevice.Viewport.Width);
            GameScreen.LoadContent(Content);
            PausedScreen.LoadContent(Content);
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            //update active screen
            switch (ScreenState.ActiveScreen)
            {
                case ScreenState.State.Title:
                {
                    exitGame = TitleScreen.Update(Audio);
                    break;
                }

                case ScreenState.State.MainMenu:
                {
                    exitGame = MainMenuScreen.Update(Audio);
                    break;
                }

                case ScreenState.State.Game:
                {
                    exitGame = GameScreen.Update(Audio);
                    break;
                }

                case ScreenState.State.Paused:
                {
                    exitGame = PausedScreen.Update(Audio);
                    break;
                }
            }

            if (exitGame)
                Exit();

            ButtonLock.PrevGamePad_P1 = GamePad.GetState(PlayerIndex.One);
            ButtonLock.PrevGamePad_P2 = GamePad.GetState(PlayerIndex.Two);
            ButtonLock.PrevGamePad_P3 = GamePad.GetState(PlayerIndex.Three);
            ButtonLock.PrevGamePad_P4 = GamePad.GetState(PlayerIndex.Four);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Start drawing
            SpriteBatch.Begin();

            //draw active screen
            switch (ScreenState.ActiveScreen)
            {
                case ScreenState.State.Title:
                {
                    TitleScreen.Draw(SpriteBatch);
                    break;
                }

                case ScreenState.State.MainMenu:
                {
                    MainMenuScreen.Draw(SpriteBatch);
                    break;
                }

                case ScreenState.State.Game:
                {
                    GameScreen.Draw(SpriteBatch);
                    break;
                }

                case ScreenState.State.Paused:
                {
                    GameScreen.Draw(SpriteBatch);
                    PausedScreen.Draw(SpriteBatch);
                    break;
                }
            }
            
            // Stop drawing
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
