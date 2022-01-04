using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoPong
{
    internal class Ball : Sprite2D
    {
        private Paddle2D _attachedPaddle;
        public Ball(Texture2D load, Vector2 location) : base(load, location)
        {
        }

        internal void AttachTo(Paddle2D paddle)
        {
            _attachedPaddle = paddle;
        }

        internal override void Update(GameTime gameTime)
        {
            Position = new Vector2(_attachedPaddle.Position.X + _attachedPaddle.Width, _attachedPaddle.Position.Y);
            base.Update(gameTime);
        }
    }
}