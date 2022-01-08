using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoPong
{
    internal abstract class Sprite2D
    {
        protected readonly Texture2D _texture;
        protected Rectangle ScreenBounds { get; private set; }

        public Rectangle Bounds { get => new Rectangle((int)Position.X, (int)Position.Y, Width, Height); }
        public Vector2 Velocity { get; set; } = Vector2.Zero;
        public int Height { get { return _texture.Height; } }
        public int Width { get { return _texture.Width; } }

        public virtual Vector2 Position { get; set; }


        public Sprite2D(Texture2D texture2d, Vector2 position, Rectangle screenBounds)
        {
            this._texture = texture2d;
            this.Position = position;
            this.ScreenBounds = screenBounds;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Position += Velocity;
        }
    }
}