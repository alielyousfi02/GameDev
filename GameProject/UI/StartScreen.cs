using GameProject.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameProject.UI
{
    public class StartScreen
    {
        private StartButton startButton;
        private Texture2D backgroundTexture;
        private Rectangle buttonRectangle;
        private Rectangle backgroundRectangle;
        private int buttonWidth = 100;
        private int buttonHeight = 75;

        public event Action StartButtonClicked;

        public StartScreen(ContentManager contentManager, Texture2D backgroundTexture, GraphicsDevice graphicsDevice)
        {
            this.backgroundTexture = contentManager.Load<Texture2D>("background");

            // Bepaal de positie van de knop in het midden van het scherm
            int buttonX = (graphicsDevice.Viewport.Width - buttonWidth) / 2;
            int buttonY = (graphicsDevice.Viewport.Height - buttonHeight) / 2;

            backgroundRectangle = new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
            buttonRectangle = new Rectangle(buttonX, buttonY, buttonWidth, buttonHeight);
            startButton = new StartButton(buttonRectangle, buttonWidth, buttonHeight, contentManager);
            startButton.ButtonClicked += OnStartButtonClicked;
        }

        private void OnStartButtonClicked()
        {
            StartButtonClicked?.Invoke();
        }

        public void Update(GameTime gameTime, MouseState mouseState)
        {
            startButton.Update(mouseState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White); // Draw the background
            startButton.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
