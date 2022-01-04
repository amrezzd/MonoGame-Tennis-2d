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

    internal abstract class Sprite2D
    {
        private readonly Texture2D texture;

        protected Vector2 velocity = Vector2.Zero;
        protected Vector2 position;
        public Vector2 Position { get { return position; } }

        public int Height { get { return texture.Height; } }

        public float Width { get { return texture.Width; } }

        public Sprite2D(Texture2D load, Vector2 location)
        {
            this.texture = load;
            this.position = location;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        internal virtual void Update(GameTime gameTime)
        {
            position += velocity;
            CheckBounds();
        }

        protected abstract void CheckBounds();


    }
}