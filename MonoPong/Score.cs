using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoPong
{
    internal class Score
    {
        private readonly SpriteFont _spriteFont;
        private readonly Rectangle _screenBounds;

        public Score(SpriteFont spriteFont, Rectangle screenBounds)
        {
            this._spriteFont = spriteFont;
            this._screenBounds = screenBounds;
        }

        public int PlayerScore { get; set; }
        public int AiPlayerScore { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {

            var scoreText = $"{PlayerScore}:{AiPlayerScore}";
            var xPosition = _screenBounds.Width / 2 - _spriteFont.MeasureString(scoreText).X / 2;
            var position = new Vector2(xPosition, _screenBounds.Height - 100);
            spriteBatch.DrawString(_spriteFont, scoreText, position, Color.White);
        }

        public void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (gameObjects.Ball.Position.X + gameObjects.Ball.Width < 0)
            {
                AiPlayerScore++;
                gameObjects.Ball.AttachTo(gameObjects.PlayerPaddle);
            }
            else if (gameObjects.Ball.Position.X > _screenBounds.Width)
            {
                PlayerScore++;
                gameObjects.Ball.AttachTo(gameObjects.PlayerPaddle);
            }
        }
    }
}