using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.UI
{
    public class StartScreen
    {
        private Texture2D _backgroundTexture;
        private GraphicsDeviceManager _graphics;

        public StartScreen(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
        }

        public void LoadContent(ContentManager content)
        {
            _backgroundTexture = content.Load<Texture2D>("background");
        }

        public void Update(GameTime gameTime)
        {
            // Hier kan je logica toevoegen voor het starten van het spel, zoals het detecteren van een toetsaanslag.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.End();
        }
    }
}

