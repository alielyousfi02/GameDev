using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interfaces
{
    internal interface IGameObject
    {
        void Update(GameTime gameTime, GraphicsDevice graphicsDevice);
        void Draw(SpriteBatch spriteBatch);
    }
}
