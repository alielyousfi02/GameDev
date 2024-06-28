using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameProject.Buttons
{
    public abstract class Button
    {
        protected Texture2D texture;
        protected Rectangle rectangle;
        protected bool isHovered;
        protected bool isClicked;
        protected int width;
        protected int height;
        protected ContentManager contentManager;

        public Button(Rectangle rectangle, int width, int height, ContentManager contentManager)
        {
            this.rectangle = rectangle;
            this.width = width;
            this.height = height;
            this.isHovered = false;
            this.isClicked = false;
            this.contentManager = contentManager;
        }

        public virtual void Update(MouseState mouseState)
        {
            Point mousePosition = new Point(mouseState.X, mouseState.Y);
            isHovered = rectangle.Contains(mousePosition);

            if (isHovered && mouseState.LeftButton == ButtonState.Pressed)
            {
                isClicked = true;
                OnClick();
            }
            else
            {
                isClicked = false;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

        protected abstract void OnClick();
    }
}
