using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoPong
{
    internal class Ball2D : Sprite2D
    {
        private readonly float _moveSpeed = 2f;
        private Paddle2D _attachedPaddle;

        public Ball2D(Texture2D texture2d, Vector2 position) : base(texture2d, position) { }

        internal void AttachTo(Paddle2D paddle)
        {
            _attachedPaddle = paddle;
        }

        internal override void Update(GameTime gameTime)
        {
            if (_attachedPaddle != null)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Velocity = new Vector2(_moveSpeed, _attachedPaddle.Velocity.Y);
                    _attachedPaddle = null;
                }
                else
                {
                    Position = new Vector2(_attachedPaddle.Position.X + _attachedPaddle.Width, _attachedPaddle.Position.Y);
                }
            }


            base.Update(gameTime);
        }
    }
}