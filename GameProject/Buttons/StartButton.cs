using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameProject.Buttons
{
    internal class StartButton : Button
    {
        public event Action ButtonClicked;

        public StartButton(Rectangle rectangle, int width, int height, ContentManager contentManager): base(rectangle, width, height, contentManager)
        {
            texture = contentManager.Load<Texture2D>("startbutton");
            this.rectangle = new Rectangle(rectangle.X, rectangle.Y, width, height);
        }

        protected override void OnClick()
        {
            Console.WriteLine("Play button clicked!");
            ButtonClicked?.Invoke();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Color buttonColor = isHovered ? Color.Gray : Color.White;
            spriteBatch.Draw(texture, rectangle, buttonColor);
        }
    }
}
