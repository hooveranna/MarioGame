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
    public class EnemySprite : ISprite
    {
        private EnemyModel EnemyModel;

        private int ticksToSkip = 5;
        private int ticksSinceLastUpdate;
        public EnemySprite(EnemyModel enemyModel)
        {
            EnemyModel = enemyModel;
        }

        public void Draw(SpriteBatch s)
        {
            if (EnemyModel.IsVisible)
            {
                int row = (int)((float)EnemyModel.CurrentFrame / (float)EnemyModel.Columns);
                int column = EnemyModel.CurrentFrame % EnemyModel.Columns;
                //Rectangle sourceRectangle = new Rectangle(BlockModel.FrameOrigin.X + BlockModel.CurrentFrame.X * BlockModel.FrameSize.X, BlockModel.FrameOrigin.Y + BlockModel.CurrentFrame.Y * BlockModel.FrameSize.Y, BlockModel.FrameSize.X, BlockModel.FrameSize.Y);
                //s.Draw(BlockModel.Texture,BlockModel.Position,sourceRectangle, Color.White,BlockModel.Rotation,BlockModel.Position,BlockModel.Scale,BlockModel.SpriteEffects,BlockModel.LayerDepth);
                Rectangle sourceRectangle = new Rectangle((int)((EnemyModel.Width) * column), (int)(EnemyModel.Height * row), (int)EnemyModel.Width - 1, (int)EnemyModel.Height);
                Rectangle destinationRectangle = new Rectangle((int)EnemyModel.Position.X, (int)EnemyModel.Position.Y, (int)(EnemyModel.Width) + (int)EnemyModel.Scale.X, (int)(EnemyModel.Height + (int)EnemyModel.Scale.Y));

                //s.Draw(EnemyModel.Texture, destinationRectangle, sourceRectangle, EnemyModel.Color);

                if (EnemyModel.LeftFacing)
                {
                    
#pragma warning disable CS0618 // Type or member is obsolete
                    s.Draw(EnemyModel.Texture, destinationRectangle: destinationRectangle, sourceRectangle: sourceRectangle, color: EnemyModel.Color, effects: SpriteEffects.FlipHorizontally);
#pragma warning restore CS0618 // Type or member is obsolete
                }
                else
                {
                    s.Draw(EnemyModel.Texture, destinationRectangle, sourceRectangle, EnemyModel.Color);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (EnemyModel.IsAnimated)
            {
                //Handle Animations and specify animation speed.
                if (ticksSinceLastUpdate >= ticksToSkip)
                {
                    EnemyModel.CurrentFrame++;
                    if ((EnemyModel.CurrentFrame - EnemyModel.TotalFrames) >= 0)
                    {
                        EnemyModel.CurrentFrame = 0;
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
