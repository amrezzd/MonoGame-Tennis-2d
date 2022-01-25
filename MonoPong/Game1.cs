using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace MonoPong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private PlayerPaddle2D _playerPaddle;
        private AiPaddle2D _aiPaddle;
        private Ball2D _ball;
        private GameObjects _gameObjects;
        private Score _score;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            TouchPanel.EnabledGestures = GestureType.VerticalDrag | GestureType.Flick | GestureType.Tap;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");

            var gameBounds = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            _playerPaddle = new PlayerPaddle2D(paddleTexture, Vector2.Zero, gameBounds);

            Vector2 aiPaddlePos = new Vector2(gameBounds.Width - _playerPaddle.Width, 0);
            _aiPaddle = new AiPaddle2D(paddleTexture, aiPaddlePos, gameBounds);

            _ball = new Ball2D(Content.Load<Texture2D>("ball"), Vector2.Zero, gameBounds);
            _ball.AttachTo(_playerPaddle);

            _score = new Score(Content.Load<SpriteFont>("retro"), gameBounds);

            _gameObjects = new GameObjects { PlayerPaddle = _playerPaddle, AiPaddle = _aiPaddle, Ball = _ball, Score = _score };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _gameObjects.TouchInput = GetTouchInput();
            _playerPaddle.Update(gameTime, _gameObjects);
            _aiPaddle.Update(gameTime, _gameObjects);
            _ball.Update(gameTime, _gameObjects);
            _score.Update(gameTime, _gameObjects);

            base.Update(gameTime);
        }

        private TouchInput GetTouchInput()
        {
            var touchInput = new TouchInput();

            while (TouchPanel.IsGestureAvailable)
            {
                var gesture = TouchPanel.ReadGesture();
                if (gesture.Delta.Y > 0)
                {
                    touchInput.Down = true;
                }
                if (gesture.Delta.Y < 0)
                {
                    touchInput.Up = true;
                }
                if (gesture.GestureType == GestureType.Tap)
                {
                    touchInput.Tapped = true;
                }
            }

            return touchInput;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _playerPaddle.Draw(_spriteBatch);
            _aiPaddle.Draw(_spriteBatch);
            _ball.Draw(_spriteBatch);
            _score.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
