using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoPong
{
    internal abstract class AbstractPaddle2D : Sprite2D
    {

        protected float MoveSpeed { get; } = 90f;

        public abstract Rectangle Surface { get; }

        protected AbstractPaddle2D(Texture2D texture2d, Vector2 position, Rectangle screenBounds) : base(texture2d, position, screenBounds) { }

        public override Vector2 Position
        {
            get => base.Position;
            set
            {
                float yBounded = MathHelper.Clamp(value.Y, 0, ScreenBounds.Height - Height);
                value.Y = yBounded;
                base.Position = value;
            }
        }

        protected void MoveTowardsTop()
        {
            Velocity = new Vector2(0, -MoveSpeed);
        }

        protected void MoveTowardsBottom()
        {
            Velocity = new Vector2(0, MoveSpeed);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(_texture, Surface, Color.Red);
        }
    }

    internal class PlayerPaddle2D : AbstractPaddle2D
    {

        public override Rectangle Surface { get => new Rectangle(Width - 3, (int)Position.Y, 3, Height); }

        public PlayerPaddle2D(Texture2D texture2d, Vector2 position, Rectangle screenBounds) : base(texture2d, position, screenBounds) { }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || gameObjects.TouchInput.Up)
            {
                MoveTowardsTop();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || gameObjects.TouchInput.Down)
            {
                MoveTowardsBottom();
            }

            base.Update(gameTime, gameObjects);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }


    internal class AiPaddle2D : AbstractPaddle2D
    {

        public override Rectangle Surface { get => new Rectangle(ScreenBounds.Width - Width, (int)Position.Y, 3, Height); }

        public AiPaddle2D(Texture2D texture2d, Vector2 position, Rectangle screenBounds) : base(texture2d, position, screenBounds) { }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            var randomThreshold = new Random().Next(30, 40);

            if (gameObjects.Ball.Position.Y + gameObjects.Ball.Height < Position.Y - randomThreshold)
            {
                MoveTowardsTop();
            }
            else if (gameObjects.Ball.Position.Y > Position.Y + Height + randomThreshold)
            {
                MoveTowardsBottom();
            }
            base.Update(gameTime, gameObjects);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

        }
    }
}