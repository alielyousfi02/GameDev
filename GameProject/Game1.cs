using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameProject.UI;  // Zorg ervoor dat de juiste namespace wordt geïmporteerd

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private StartScreen _startScreen;

        private enum GameState
        {
            StartMenu,
            Playing,
            GameOver
        }

        private GameState _currentGameState = GameState.StartMenu;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _startScreen = new StartScreen(_graphics);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _startScreen.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (_currentGameState == GameState.StartMenu)
            {
                _startScreen.Update(gameTime);

                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    _currentGameState = GameState.Playing;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (_currentGameState == GameState.StartMenu)
            {
                _startScreen.Draw(_spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}
