using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoPong
{
    internal abstract class AbstractPaddle2D : Sprite2D
    {

        protected float MoveSpeed { get; } = 2f;

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

        protected void MoveTowardsUp()
        {
            Velocity = new Vector2(0, -MoveSpeed);
        }

        protected void MoveTowardsDown()
        {
            Velocity = new Vector2(0, MoveSpeed);
        }
    }

    internal class PlayerPaddle2D : AbstractPaddle2D
    {

        public PlayerPaddle2D(Texture2D texture2d, Vector2 position, Rectangle screenBounds) : base(texture2d, position, screenBounds) { }

        internal override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                MoveTowardsUp();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                MoveTowardsDown();
            }

            base.Update(gameTime, gameObjects);
        }
    }


    internal class AiPaddle2D : AbstractPaddle2D
    {
        public AiPaddle2D(Texture2D texture2d, Vector2 position, Rectangle screenBounds) : base(texture2d, position, screenBounds) { }

        internal override void Update(GameTime gameTime, GameObjects gameObjects)
        {

            if (gameObjects.Ball.Position.Y + gameObjects.Ball.Height < Position.Y)
            {
                MoveTowardsUp();
            }
            else if (gameObjects.Ball.Position.Y > Position.Y + Height)
            {
                MoveTowardsDown();
            }
            base.Update(gameTime, gameObjects);
        }
    }
}