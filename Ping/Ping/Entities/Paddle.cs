using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Ping.Graphics;
using Ping.Global;

namespace Ping.Entities
{
    class Paddle
    {
        private Graphics_GameScreen graphics = new Graphics.Graphics_GameScreen();

        private Texture2D texture;
        private Vector2 texturePosition;
        public Vector2 Position;
        public int Width;
        public int Height;

        public bool Horizontal;

        private float minSpeed = 0; //current min speed the paddle can move at (CANNOT BE NEGATIVE)
        private float maxSpeed = 10; //current max speed the paddle can move at
        public float Speed = 0; //current speed of paddle

        private float acceleration = 1.3f; //[FLAT VALUE] rate of acceleration when moved by the player
        private float deceleration = .93f; //[PERCENTAGE] rate the paddle decelerates by every frame
        private float minSpeedCutoff; //stops the paddle after it decelerates past a certain point (1% of speed range)

        public void Initialize(Vector2 texturePosition, Vector2 position, bool horizontal)
        {
            this.texturePosition = texturePosition;
            Position = position;
            Horizontal = horizontal;
            
            if (horizontal)
            {
                Width = Constants.PADDLE_LENGTH_LONG;
                Height = Constants.PADDLE_LENGTH_SHORT;
            }
            else
            {
                Width = Constants.PADDLE_LENGTH_SHORT;
                Height = Constants.PADDLE_LENGTH_LONG;
            }

            minSpeedCutoff = (maxSpeed - minSpeed) / 100;
        }

        public void LoadContent(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Update(float thumbstickPressure)
        {
            if (Horizontal)
            {
                setPosition(update(thumbstickPressure, Position.X), Position.Y);

                //wall collision test
                float oldX = Position.X;
                setPosition(MathHelper.Clamp(Position.X,
                                            (float)(graphics.PlayAreaPosition.X + Constants.PADDLE_LENGTH_SHORT),
                                            (float)(graphics.PlayAreaPosition.X + Graphics_GameScreen.PLAY_AREA_WIDTH - Constants.PADDLE_LENGTH_SHORT - Constants.PADDLE_LENGTH_LONG)),
                            Position.Y);

                //if collided with wall, stop paddle
                if (oldX != Position.X)
                    Speed = 0;
            }
            else
            {
                setPosition(Position.X, update(-thumbstickPressure, Position.Y));

                //wall collision test
                float oldY = Position.Y;
                setPosition(Position.X,
                            MathHelper.Clamp(Position.Y,
                                            (float)(graphics.PlayAreaPosition.Y + Constants.PADDLE_LENGTH_SHORT),
                                            (float)(graphics.PlayAreaPosition.Y + Graphics_GameScreen.PLAY_AREA_HEIGHT - Constants.PADDLE_LENGTH_SHORT - Constants.PADDLE_LENGTH_LONG)));

                //if collided with wall, stop paddle
                if (oldY != Position.Y)
                    Speed = 0;
            }
        }

        private float update(float thumbstickPressure, float paddlePosition)
        {
            if (Settings.PaddleInertiaActive)
            {
                if (thumbstickPressure != 0) //if player moving paddle
                {
                    //caps paddle at max speed
                    if (Math.Abs(Speed + acceleration * thumbstickPressure) < maxSpeed)
                        Speed += acceleration * thumbstickPressure;
                    else
                    {
                        if (Speed < 1)
                            Speed = -maxSpeed;
                        else
                            Speed = maxSpeed;
                    }
                }
                else //player not moving paddle
                {
                    //caps paddle at min speed
                    if (Math.Abs(Speed * deceleration) < minSpeedCutoff)
                        Speed = minSpeed;
                    else
                        Speed *= deceleration;
                }

                paddlePosition += Speed;
            }
            else
                paddlePosition += thumbstickPressure * maxSpeed;

            return (float)paddlePosition;
        }

        private void setPosition(float x, float y)
        {
            texturePosition.X += x - Position.X;
            texturePosition.Y += y - Position.Y;
            Position.X = x;
            Position.Y = y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Horizontal)
                spriteBatch.Draw(texture, texturePosition, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
            else
                spriteBatch.Draw(texture, texturePosition, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }
    }
}