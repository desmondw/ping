using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using Ping.Graphics;
using Ping.Global;
using Ping.Entities;
using Ping.Sound;

namespace Ping.Screens
{
    class GameScreen
    {
        Graphics_GameScreen graphics = new Graphics.Graphics_GameScreen();
        bool exitGame = false;

        //used to test ball collision with play area border
        Rectangle PlayAreaRectangle;

        Paddle PaddleTop = new Paddle();
        Paddle PaddleBottom = new Paddle();
        Paddle PaddleLeft = new Paddle();
        Paddle PaddleRight = new Paddle();
        Ball Ball = new Ball();

        Texture2D Test;

        public void Initialize(int titleSafeHeight, int actionHeight, int actionWidth)
        {
            PlayAreaRectangle = new Rectangle((int)graphics.PlayAreaPosition.X, (int)graphics.PlayAreaPosition.Y, Graphics_GameScreen.PLAY_AREA_WIDTH, Graphics_GameScreen.PLAY_AREA_HEIGHT);

            #region Initializing: Paddle position and texture position
            Vector2 topPosition = new Vector2(graphics.PlayAreaPosition.X + Graphics_GameScreen.PLAY_AREA_WIDTH / 2 - Constants.PADDLE_LENGTH_LONG / 2, graphics.PlayAreaPosition.Y);
            Vector2 bottomPosition = new Vector2(graphics.PlayAreaPosition.X + Graphics_GameScreen.PLAY_AREA_WIDTH / 2 - Constants.PADDLE_LENGTH_LONG / 2, graphics.PlayAreaPosition.Y + Graphics_GameScreen.PLAY_AREA_HEIGHT - Constants.PADDLE_LENGTH_SHORT);
            Vector2 leftPosition = new Vector2(graphics.PlayAreaPosition.X, graphics.PlayAreaPosition.Y + Graphics_GameScreen.PLAY_AREA_HEIGHT / 2 - Constants.PADDLE_LENGTH_LONG / 2);
            Vector2 rightPosition = new Vector2(graphics.PlayAreaPosition.X + Graphics_GameScreen.PLAY_AREA_WIDTH - Constants.PADDLE_LENGTH_SHORT, graphics.PlayAreaPosition.Y + Graphics_GameScreen.PLAY_AREA_HEIGHT / 2 - Constants.PADDLE_LENGTH_LONG / 2);

            Vector2 topPositionTexture = topPosition;
            Vector2 bottomPositionTexture = bottomPosition;
            Vector2 leftPositionTexture = leftPosition;
            Vector2 rightPositionTexture = rightPosition;

            topPositionTexture.Y = topPositionTexture.Y - Graphics_GameScreen.PADDLE_TEXTURE_LENGTH_SHORT + Constants.PADDLE_LENGTH_SHORT;
            //bottomPositionTexture.Y = bottomPositionTexture.Y;
            leftPositionTexture.X = leftPositionTexture.X - Graphics_GameScreen.PADDLE_TEXTURE_LENGTH_SHORT + Constants.PADDLE_LENGTH_SHORT;
            //rightPositionTexture.X = rightPositionTexture.X;
            #endregion

            PaddleTop.Initialize(topPositionTexture, topPosition, true);
            PaddleBottom.Initialize(bottomPositionTexture, bottomPosition, true);
            PaddleLeft.Initialize(leftPositionTexture, leftPosition, false);
            PaddleRight.Initialize(rightPositionTexture, rightPosition, false);
            Ball.Initialize(new Vector2(graphics.PlayAreaCenter.X - Constants.BALL_SIZE / 2, graphics.PlayAreaCenter.Y - Constants.BALL_SIZE / 2));
        }

        public void LoadContent(ContentManager content)
        {
            //Load the background texture for the screen
            graphics.Background_GameArea = content.Load<Texture2D>(Constants.FILEPATH_BACKGROUNDS + "Game_GameAreaBG");

            PaddleTop.LoadContent(content.Load<Texture2D>(Constants.FILEPATH_GRAPHICS + "paddleTop"));
            PaddleBottom.LoadContent(content.Load<Texture2D>(Constants.FILEPATH_GRAPHICS + "paddleBottom"));
            PaddleLeft.LoadContent(content.Load<Texture2D>(Constants.FILEPATH_GRAPHICS + "paddleLeft"));
            PaddleRight.LoadContent(content.Load<Texture2D>(Constants.FILEPATH_GRAPHICS + "paddleRight"));
            Ball.LoadContent(content, content.Load<Texture2D>(Constants.FILEPATH_GRAPHICS + "ball"));

            Test = content.Load<Texture2D>(Constants.FILEPATH_GRAPHICS + "test");
        }

        public bool Update(Audio audio)
        {
            //handle state changes
            if (ButtonLock.PressedNotHeld(ButtonLock.PrevGamePad_P1.Buttons.B, GamePad.GetState(PlayerIndex.One).Buttons.B))
            {
                ScreenState.ActiveScreen = ScreenState.State.MainMenu;
                return false;
            }
            else if (ButtonLock.PressedNotHeld(ButtonLock.PrevGamePad_P1.Buttons.Start, GamePad.GetState(PlayerIndex.One).Buttons.Start))
            {
                audio.PlaySound(Audio.SFX.MenuSelect);
                ScreenState.ActiveScreen = ScreenState.State.Paused;
                return false;
            }

            UpdatePaddles();
            UpdateBall(audio);
            return exitGame;
        }

        private void UpdatePaddles()
        {
            PaddleTop.Update(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X);
            PaddleBottom.Update(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X);
            PaddleLeft.Update(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y);
            PaddleRight.Update(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y);
        }

        private void UpdateBall(Audio audio)
        {
            List<Paddle> paddles = new List<Paddle>();
            paddles.Add(PaddleTop);
            paddles.Add(PaddleBottom);
            paddles.Add(PaddleLeft);
            paddles.Add(PaddleRight);

            Ball.Update(paddles, PlayAreaRectangle, audio);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Draw_Background(spriteBatch);
            Ball.Draw(spriteBatch);
            PaddleTop.Draw(spriteBatch);
            PaddleBottom.Draw(spriteBatch);
            PaddleLeft.Draw(spriteBatch);
            PaddleRight.Draw(spriteBatch);
        }

        public void Draw_Background(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(graphics.Background_GameArea, graphics.GameAreaPosition, Color.White);

            //spriteBatch.Draw(Test, new Rectangle((int)graphics.GameAreaPosition.X, (int)graphics.GameAreaPosition.Y, Graphics_GameScreen.GAME_AREA_WIDTH, Graphics_GameScreen.GAME_AREA_HEIGHT), Color.White);
            //spriteBatch.Draw(Test, new Rectangle((int)graphics.PlayAreaPosition.X, (int)graphics.PlayAreaPosition.Y, Graphics_GameScreen.PLAY_AREA_WIDTH, Graphics_GameScreen.PLAY_AREA_HEIGHT), Color.Gray);
        }
    }
}