using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoPong
{
    internal class Ball : Sprite2D
    {
        private Paddle paddle;
        public Ball(Texture2D load, Vector2 location) : base(load, location)
        {
        }

        protected override void CheckBounds()
        {
            // no boundaries yet
        }

        internal void AttachTo(Paddle paddle)
        {
            this.paddle = paddle;
        }

        internal override void Update(GameTime gameTime)
        {
            position = paddle.Position;
            position.X += paddle.Width;
            base.Update(gameTime);
        }
    }
}