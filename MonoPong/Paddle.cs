using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoPong
{
    internal class Paddle : Sprite2D
    {
        private readonly float moveSpeed = 2f;
        private readonly Rectangle screenBounds;

        public Paddle(Texture2D load, Vector2 location, Rectangle screenBounds) : base(load, location)
        {
            this.screenBounds = screenBounds;
        }

        internal override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocity = new Vector2(0, -moveSpeed);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {

                velocity = new Vector2(0, moveSpeed);
            }

            base.Update(gameTime);
        }


        protected override void CheckBounds()
        {
            float yLocation = MathHelper.Clamp(position.Y, 0, screenBounds.Height - Height);
            position.Y = yLocation;
        }
    }
}