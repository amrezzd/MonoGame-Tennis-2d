using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoPong
{
    internal class Ball2D : Sprite2D
    {
        private readonly float _moveSpeed = 2f;
        private readonly float _bounciness = 0.75f;

        private AbstractPaddle2D _attachedPaddle;

        public Ball2D(Texture2D texture2d, Vector2 position, Rectangle screenBounds) : base(texture2d, position, screenBounds)
        {
        }

        public override Vector2 Position
        {
            get => base.Position; set
            {
                base.Position = value;
                if (Position.Y <= 0 || Position.Y >= ScreenBounds.Height - Height)
                {
                    Velocity = new Vector2(Velocity.X, -Velocity.Y);
                }
            }
        }


        public void AttachTo(AbstractPaddle2D paddle)
        {
            _attachedPaddle = paddle;
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (_attachedPaddle != null)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space) || gameObjects.TouchInput.Tapped)
                {
                    Velocity = new Vector2(_moveSpeed, _attachedPaddle.Velocity.Y * _bounciness);
                    _attachedPaddle = null;
                }
                else
                {
                    Position = new Vector2(_attachedPaddle.Position.X + _attachedPaddle.Width, _attachedPaddle.Position.Y);
                }
            }
            else
            {
                // Check if the ball is touched player's paddle surface while moving left,
                // or it touched ai paddle surface while right
                if (
                    (Bounds.Intersects(gameObjects.PlayerPaddle.Surface) && Velocity.X < 0) ||
                    (Bounds.Intersects(gameObjects.AiPaddle.Surface) && Velocity.X > 0)
                    )
                {

                    AbstractPaddle2D collidedPaddle = Velocity.X < 0 ? gameObjects.PlayerPaddle : gameObjects.AiPaddle;

                    // Change the ball direction horizontally
                    Velocity = new Vector2(-Velocity.X, Velocity.Y);

                    // if ball touched the paddle corner, we need to change vertical direction too
                    float ballCenterPos = Position.Y + Height / 2;
                    if (
                        (ballCenterPos < collidedPaddle.Position.Y && Velocity.Y > 0) ||
                        (ballCenterPos > collidedPaddle.Position.Y + collidedPaddle.Height && Velocity.Y < 0)
                        )
                    {
                        Velocity = new Vector2(Velocity.X, -Velocity.Y);
                    }
                }
            }

            base.Update(gameTime, gameObjects);
        }
    }
}