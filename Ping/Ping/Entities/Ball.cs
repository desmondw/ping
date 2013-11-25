using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

using Ping.Graphics;
using Ping.Global;
using Ping.Sound;

namespace Ping.Entities
{
    class Ball
    {
        private Graphics_GameScreen graphics = new Graphics.Graphics_GameScreen();

        private Texture2D texture;

        public Vector2 spawnPosition;
        public Vector2 Position;
        public int Width;
        public int Height;

        private float minSpeed = 2; //current min speed of ball
        private float maxSpeed = 8; //current max speed of ball
        private float defaultSpeed = 5; //regular speed when the ball is created
        public float Speed; //current active speed
        public float Direction; //angle of ball's direction in degrees

        private bool paddleHitLastFrame = false; //tracks when ball hits a paddle to prevent zig-zagging inside of one

        //overload for no speed given: uses default speed and random direction from 0-360
        public void Initialize(Vector2 position)
        {
            Random rand = new Random();
            Initialize(position, (float)rand.NextDouble() * 360, defaultSpeed);
        }

        public void Initialize(Vector2 position, float direction, float speed)
        {
            spawnPosition = position;
            Position = position;
            Direction = direction;
            Speed = speed;

            Width = Constants.BALL_SIZE;
            Height = Constants.BALL_SIZE;
        }

        public void LoadContent(ContentManager content, Texture2D texture)
        {
            this.texture = texture;
        }

        public void Update(List<Paddle> paddles, Rectangle playAreaRectangle, Audio audio)
        {
            Update_CollisionDetection(paddles, playAreaRectangle, audio);
        }

        public void Update_CollisionDetection(List<Paddle> paddles, Rectangle playAreaRectangle, Audio audio)
        {
            //collision detection with wall
            if (!playAreaRectangle.Contains(GetRectangle())) //if not in game window (aka collided with wall)
            {
                if (Settings.SillyMode)
                    audio.PlaySillyMaleWall();
                else
                    audio.PlaySound(Audio.SFX.BallWallCollision);
                Position = spawnPosition;
                Direction = (float)new Random().NextDouble() * 360;
                Speed = defaultSpeed;
            }
            else
            {
                bool paddleHit = false;

                //collision detection with paddles
                for (int i = 0; i < paddles.Count; i++)
                {
                    if (paddles[i].GetRectangle().Intersects(GetRectangle()))
                    {
                        //if paddle was hit (and ball is not stuck), change balls direction and speed
                        if (!paddleHitLastFrame)
                        {
                            if (Settings.SillyMode)
                                audio.PlaySillyMalePaddle();
                            else
                                audio.PlaySound(Audio.SFX.BallPaddleCollision);

                            BallPaddleCollision_AddForce(paddles[i]);
                        }

                        paddleHit = true;
                    }
                }

                paddleHitLastFrame = paddleHit;
                Update_Move();
            }
        }

        public void BallPaddleCollision_AddForce(Paddle paddle)
        {
            Direction = Ping.Global.MathCalc.SimplifyAngle(Direction);

            if (paddle.Horizontal)
                Direction = 360 - Direction;
            else
                Direction = 180 - Direction;

            //if paddle is moving, add force to the ball
            //if (paddle.speed != 0)
            //{
            //    float vectorAngle = 0;

            //    //gets proper angle for trigonometry below
            //    if (paddle.horizontal)
            //    {
            //        if ((90 < direction && direction < 180) || (270 < direction && direction < 360))
            //            vectorAngle = 90 - (direction % 90);
            //        else
            //            vectorAngle = direction % 90;
            //    }
            //    else
            //    {
            //        if ((0 < direction && direction < 90) || (180 < direction && direction < 270))
            //            vectorAngle = 90 - (direction % 90);
            //        else
            //            vectorAngle = direction % 90;
            //    }

            //    float vectorSpeed = speed * Math.Cos(vectorAngle);
            //    vectorSpeed += paddle.speed * Settings.EnergyConservation_BallPaddle;
            //    direction = Math.Acos(vectorSpeed / speed * Constants.DEGREE_MULTIPLIER) + (direction - direction % 90);
            //}
        }

        public void Update_Move()
        {
            //updating position based on speed and direction
            Position.X += (float)(Speed * Math.Cos(Direction * Constants.DEGREE_MULTIPLIER));
            Position.Y += (float)(Speed * Math.Sin(Direction * Constants.DEGREE_MULTIPLIER));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }
    }
}
