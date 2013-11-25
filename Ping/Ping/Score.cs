using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping
{
    class Score
    {
        private int score = 0;
        public string scoreText = "0";
        public SpriteFont font;
        public Color color;
        private byte alpha = 204; //the score's transparency

        public Vector2 position;
        public Vector2 center;


        public void Initialize(SpriteFont font, Color color, GameWindow gameWindow)
        {
            this.font = font;
            color.A = alpha;
            this.color = color;

            center = font.MeasureString(scoreText) / 2;
            UpdateScore(0, gameWindow);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, scoreText, position, color, 0, new Vector2(0), 1.0f, SpriteEffects.None, 1f);
        }

        public int GetScore()
        {
            return score;
        }

        public void UpdateScore(int increment, GameWindow gameWindow)
        {
            score += increment;
            PositionScoreText(gameWindow);
        }

        public void ResetScore(GameWindow gameWindow)
        {
            score = 0;
            PositionScoreText(gameWindow);
        }

        private void PositionScoreText(GameWindow gameWindow)
        {
            scoreText = score.ToString();
            //position.X = gameWindow.CenterScreen.X - font.MeasureString(scoreText).X / 2;
            //position.Y = gameWindow.CenterScreen.Y - font.MeasureString(scoreText).Y / 2;
        }
    }
}
