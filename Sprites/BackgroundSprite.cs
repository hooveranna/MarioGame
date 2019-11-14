using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Sprites
{
    class BackgroundSprite : ISprite
    {

        private Rectangle startPos = new Rectangle(-1000, -600, 1280, 720);
        private Rectangle currentPos;
        private Texture2D texture;
        private int rows = 1;
        private int columns = 1;
        private int currentFrame;
        private Vector2 scale;
        public BackgroundSprite(Texture2D texture, int levelWidth, int levelHeight)
        {
            this.scale = new Vector2(levelWidth + 1280, levelHeight + 720);
            this.texture = texture;
            currentPos = startPos;
            currentFrame = 0;

        }
        public void Draw(SpriteBatch s)
        {

            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width * 5, height * 5);
            Rectangle destinationRectangle = new Rectangle(currentPos.X, currentPos.Y, width + (int)scale.X, height + (int)scale.Y);

            s.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
