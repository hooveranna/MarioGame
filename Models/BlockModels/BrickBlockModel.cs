using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ParticleEngine2D;
using Sprint_4.Sprites;
using Sprint_4.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Models.BlockModels
{
    class BrickBlockModel : BlockModel
    {
        public BrickBlockModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity)
            : base(blockSpriteFactory)
        {
            //Initialize state first
            CurrentState = new BrickBlockStandardState(this);
            CurrentState.Enter(null);

            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            Columns = 1;
            Rows = 1;
            LayerDepth = 1;

            //Particles
            Texture2D brickTexture = BlockSpriteFactory.GetBlockSprite("brick");
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(brickTexture);
            ParticleEngine = new ParticleEngine(textures, Position);


            Texture = brickTexture;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            Velocity = velocity;

        }

        public BrickBlockModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity, Color color)
           : base(blockSpriteFactory)
        {
            //For Secret Bricks

            //Initialize state first
            CurrentState = new BrickBlockStandardState(this);
            CurrentState.Enter(null);

            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            Columns = 1;
            Rows = 1;
            LayerDepth = 1;

            //Particles
            Texture2D brickTexture = BlockSpriteFactory.GetBlockSprite("brickcolored");
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(brickTexture);
            ParticleEngine = new ParticleEngine(textures, Position);
            Color = color;

            Texture = brickTexture;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            Velocity = velocity;


        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
                
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            ParticleEngine.Draw(spriteBatch);

        }
        public override void CollisionResponseBottom(ICollidable collidable)
        {
            if (collidable.State is MarioSuperState || collidable.State is MarioFireState)
            {
                this.CurrentState.ExplodedTransition();
            }
            else if (collidable.State is MarioStandardState)
            {
                this.CurrentState.BumpTransition();
            }
        }
        /*
        public override void CollisionResponseSide(ICollidable collidable)
        {
            if (collidable is ItemModel)
            {
                ItemModel item = (ItemModel)collidable;
                item.CollisionResponseSide(this);
            }
        }*/


    }
}
