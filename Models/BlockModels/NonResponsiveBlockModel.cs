using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Sprites;
using Sprint_4.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Models.BlockModels
{
    class DiamondBlockModel : BlockModel
    {
        public DiamondBlockModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity)
            : base(blockSpriteFactory)
        {
            //Initialize Texture first
            Texture = BlockSpriteFactory.GetBlockSprite("diamond");

            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            Columns = 1;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            Velocity = velocity;
        }

    }
    class UsedBlockModel : BlockModel
    {
        public UsedBlockModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity)
            : base(blockSpriteFactory)
        {
            //Initialize Texture first
            Texture = BlockSpriteFactory.GetBlockSprite("used");
            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            Columns = 1;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            Velocity = velocity;
        }

    }
    class PipeBlockModel : BlockModel
    {
        public PipeBlockModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity)
            : base(blockSpriteFactory)
        {
            //Initialize Texture first
            Texture = BlockSpriteFactory.GetBlockSprite("pipetop");

            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            Columns = 1;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            Velocity = velocity;
        }
    }
    class PipeLowerModel : BlockModel
    {
        public PipeLowerModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity)
            : base(blockSpriteFactory)
        {
            //Initialize Texture first
            Texture = BlockSpriteFactory.GetBlockSprite("pipelower");

            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            Columns = 1;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            Velocity = velocity;
        }
    }
    class GroundBlockModel : BlockModel
    {
        public GroundBlockModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity)
            : base(blockSpriteFactory)
        {
            //Initialize Texture first
            Texture = BlockSpriteFactory.GetBlockSprite("ground");

            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            Columns = 1;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            Velocity = velocity;
        }
        public GroundBlockModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity, Color color)
           : base(blockSpriteFactory)
        {
            //Initialize Texture first
            Texture = BlockSpriteFactory.GetBlockSprite("groundcolored");

            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            Columns = 1;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            Velocity = velocity;
            Color = color;
        }
    }
}
