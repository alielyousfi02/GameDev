using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.Levels
{
    public abstract class Level
    {
        protected Texture2D tilesetTexture;
        protected Texture2D backgroundTexture;
        protected int tileWidth;
        protected int tileHeight;
        protected int[,] map;
        protected int mapWidth;
        protected int mapHeight;
        protected Rectangle backgroundRectangle;

        public Level(int tileWidth, int tileHeight)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
        }

        public virtual void LoadContent(ContentManager contentManager, string tilesetPath, string backgroundPath, int[,] mapData, GraphicsDevice graphicsDevice)
        {
            tilesetTexture = contentManager.Load<Texture2D>(tilesetPath);
            backgroundTexture = contentManager.Load<Texture2D>(backgroundPath);
            map = mapData;
            mapWidth = map.GetLength(1);
            mapHeight = map.GetLength(0);
            backgroundRectangle = new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    int tileId = map[y, x];
                    if (tileId >= 0)
                    {
                        int tilesetColumns = tilesetTexture.Width / tileWidth;
                        int tilesetX = (tileId % tilesetColumns) * tileWidth;
                        int tilesetY = (tileId / tilesetColumns) * tileHeight;
                        Rectangle sourceRectangle = new Rectangle(tilesetX, tilesetY, tileWidth, tileHeight);
                        Rectangle destinationRectangle = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight);

                        spriteBatch.Draw(tilesetTexture, destinationRectangle, sourceRectangle, Color.White);
                    }
                }
            }

            spriteBatch.End();
        }
    }
}
