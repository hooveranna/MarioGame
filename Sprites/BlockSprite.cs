using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Models;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sprint_4.Sprites.BlockSprites
{
    public class BlockSprite : ISprite
    {
        private BlockModel BlockModel;

        private int ticksToSkip = 5;
        private int ticksSinceLastUpdate;
        public BlockSprite(BlockModel blockModel)
        {
            BlockModel = blockModel;

        }

        public void Draw(SpriteBatch s)
        {
            int row = (int)((float)BlockModel.CurrentFrame / (float)BlockModel.Columns);
            int column = BlockModel.CurrentFrame % BlockModel.Columns;
            Rectangle sourceRectangle = new Rectangle((int)BlockModel.Width * column, (int)BlockModel.Height * row, (int)BlockModel.Width, (int)BlockModel.Height);
            Rectangle destinationRectangle = new Rectangle((int)BlockModel.Position.X, (int)BlockModel.Position.Y, (int)BlockModel.Width + (int)BlockModel.Scale.X, (int)BlockModel.Height + (int)BlockModel.Scale.Y);
            s.Draw(BlockModel.Texture, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            if (BlockModel.IsAnimated)
            {
                //Handle Animations and specify animation speed.
                if (ticksSinceLastUpdate >= ticksToSkip) {
                    BlockModel.CurrentFrame++;
                    if ((BlockModel.CurrentFrame - BlockModel.TotalFrames) >= 0)
                    {
                        BlockModel.CurrentFrame = 0;
                    }
                    ticksSinceLastUpdate = 0;
                }
                else
                {
                    ticksSinceLastUpdate++;
                }
            }
        }
    }
}
