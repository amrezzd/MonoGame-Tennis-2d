using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoPong
{
    internal class Paddle2D : Sprite2D
    {
        private readonly float _moveSpeed = 2f;
        private readonly Rectangle _screenBounds;

        public override Vector2 Position
        {
            get => base.Position; set
            {
                float yBounded = MathHelper.Clamp(value.Y, 0, _screenBounds.Height - Height);
                value.Y = yBounded;
                base.Position = value;
            }
        }

        public Paddle2D(Texture2D texture2d, Vector2 location, Rectangle screenBounds) : base(texture2d, location)
        {
            this._screenBounds = screenBounds;
        }

        internal override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Velocity = new Vector2(0, -_moveSpeed);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {

                Velocity = new Vector2(0, _moveSpeed);
            }

            base.Update(gameTime);
        }
    }
}