using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Project2
{
    internal class Paddle : Sprite2D
    {
        public Paddle(Texture2D load, Vector2 location) : base(load, location)
        {
        }


    }

    internal class Sprite2D
    {
        private Texture2D texture2d;
        private Vector2 location2d;

        public Sprite2D(Texture2D load, Vector2 location)
        {
            this.texture2d = load;
            this.location2d = location;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2d, location2d, Color.White);
        }
    }
}