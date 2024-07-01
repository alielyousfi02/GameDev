using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameProject.UI;
using GameProject.Levels;

using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private StartScreen _startScreen;
        private Level1 _level1;
        private Texture2D _backgroundTexture;
        private ContentManager _contentManager;


        private enum GameState
        {
            StartMenu,
            Level1,
            Playing,
            GameOver
        }

        private GameState _currentGameState = GameState.StartMenu;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1440;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _backgroundTexture = Content.Load<Texture2D>("background");

            _contentManager = Content;

            _startScreen = new StartScreen(_contentManager, _backgroundTexture, GraphicsDevice);
            _startScreen.StartButtonClicked += StartScreen_StartButtonClicked;

            _level1 = new Level1();
            _level1.LoadLevel(Content, GraphicsDevice);

            // Load hero and enemies
          
        }

        private void StartScreen_StartButtonClicked()
        {
            _currentGameState = GameState.Level1;
        }

        protected override void Update(GameTime gameTime)
        {
            if (_currentGameState == GameState.StartMenu)
            {
                MouseState mouseState = Mouse.GetState();
                _startScreen.Update(gameTime, mouseState);
            }
            else if (_currentGameState == GameState.Level1)
            {
               
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
            else if (_currentGameState == GameState.Level1)
            {
                _level1.Draw(_spriteBatch);
              
            }

            base.Draw(gameTime);
        }
    }
}
