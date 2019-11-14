using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Sprites
{
    class CastleSprite : ISprite
    {

        private Rectangle startPos = new Rectangle(5278, 472, 48, 36);
        private Rectangle currentPos;
        private Texture2D texture;
        private int rows = 1;
        private int columns = 1;
        private int currentFrame;
        private Vector2 scale;
        public CastleSprite(Texture2D texture)
        {
            this.scale = new Vector2(10,10);
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(currentPos.X, currentPos.Y, width + (int)scale.X, height + (int)scale.Y);

            s.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
