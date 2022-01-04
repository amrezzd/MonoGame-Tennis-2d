using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoPong
{
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