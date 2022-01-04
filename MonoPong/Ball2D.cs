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

        private PlayerPaddle2D _attachedPaddle;

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
        public Ball2D(Texture2D texture2d, Vector2 position, Rectangle screenBounds) : base(texture2d, position, screenBounds)
        {
        }

        internal void AttachTo(PlayerPaddle2D paddle)
        {
            _attachedPaddle = paddle;
        }

        internal override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (_attachedPaddle != null)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Velocity = new Vector2(_moveSpeed, _attachedPaddle.Velocity.Y * _bounciness);
                    _attachedPaddle = null;
                }
                else
                {
                    Position = new Vector2(_attachedPaddle.Position.X + _attachedPaddle.Width, _attachedPaddle.Position.Y);
                }
            }

            base.Update(gameTime, gameObjects);
        }
    }
}