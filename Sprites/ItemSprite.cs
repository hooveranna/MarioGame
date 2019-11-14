using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Models;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//PLACEHOLDER. When the Tile Map is made, the Draw and Update functions can be moved to the Tile Map as long as the Block Models values are defined.
namespace Sprint_4.Sprites
{
    public class ItemSprite : ISprite
    {
        public ItemModel ItemModel { get; set; }

        public int TicksToSkip { get; set; }
        public int TicksSinceLastUpdate { get; set; }
        public ItemSprite(ItemModel itemModel)
        {
            ItemModel = itemModel;
            TicksToSkip = 5;
        }

        public void Draw(SpriteBatch s)
        {
            if (ItemModel.IsVisible)
            {

                int row = (int)((float)ItemModel.CurrentFrame / (float)ItemModel.Columns);
                int column = ItemModel.CurrentFrame % ItemModel.Columns;
                //Rectangle sourceRectangle = new Rectangle(BlockModel.FrameOrigin.X + BlockModel.CurrentFrame.X * BlockModel.FrameSize.X, BlockModel.FrameOrigin.Y + BlockModel.CurrentFrame.Y * BlockModel.FrameSize.Y, BlockModel.FrameSize.X, BlockModel.FrameSize.Y);
                //s.Draw(BlockModel.Texture,BlockModel.Position,sourceRectangle, Color.White,BlockModel.Rotation,BlockModel.Position,BlockModel.Scale,BlockModel.SpriteEffects,BlockModel.LayerDepth);
                Rectangle sourceRectangle = new Rectangle((int)ItemModel.Width * column, (int)ItemModel.Height * row, (int)ItemModel.Width, (int)ItemModel.Height);
                Rectangle destinationRectangle = new Rectangle((int)ItemModel.Position.X, (int)ItemModel.Position.Y, (int)ItemModel.Width + (int)ItemModel.Scale.X, (int)ItemModel.Height + (int)ItemModel.Scale.Y);
                s.Draw(ItemModel.Texture, destinationRectangle, sourceRectangle, ItemModel.Color);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (ItemModel.IsAnimated)
            {
                //Handle Animations and specify animation speed.
                if (TicksSinceLastUpdate >= TicksToSkip)
                {
                    ItemModel.CurrentFrame++;
                    if ((ItemModel.CurrentFrame - ItemModel.TotalFrames) >= 0)
                    {
                        ItemModel.CurrentFrame = 0;
                    }
                    TicksSinceLastUpdate = 0;
                }
                else
                {
                    TicksSinceLastUpdate++;
                }
            }
        }
    }
}
