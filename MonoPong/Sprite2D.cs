using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoPong
{
    internal abstract class Sprite2D
    {
        private readonly Texture2D _texture;

        public virtual Vector2 Position { get; set; }

        public Vector2 Velocity { get; set; } = Vector2.Zero;
        public int Height { get { return _texture.Height; } }

        public float Width { get { return _texture.Width; } }

        public Sprite2D(Texture2D texture2d, Vector2 position)
        {
            this._texture = texture2d;
            this.Position = position;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        internal virtual void Update(GameTime gameTime)
        {
            Position += Velocity;
        }
    }
}