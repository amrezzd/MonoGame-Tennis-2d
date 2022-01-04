using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");
            
            _playerPaddle = new PlayerPaddle2D(paddleTexture, Vector2.Zero, Window.ClientBounds);

            Vector2 aiPaddlePos = new Vector2(Window.ClientBounds.Width - _playerPaddle.Width, 0);
            _aiPaddle = new AiPaddle2D(paddleTexture, aiPaddlePos, Window.ClientBounds);

            _ball = new Ball2D(Content.Load<Texture2D>("ball"), Vector2.Zero, Window.ClientBounds);
            _ball.AttachTo(_playerPaddle);

            _gameObjects = new GameObjects { PlayerPaddle = _playerPaddle, AiPaddle = _aiPaddle, Ball = _ball};
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _playerPaddle.Update(gameTime, _gameObjects);
            _aiPaddle.Update(gameTime, _gameObjects);
            _ball.Update(gameTime, _gameObjects);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _playerPaddle.Draw(_spriteBatch);
            _aiPaddle.Draw(_spriteBatch);
            _ball.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
