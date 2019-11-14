using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Sprites;
using Sprint_4.Collision;
using Sprint_4.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Models.BlockModels
{
    class WarpPipeBlockModel : BlockModel
    {
        public WarpPipeBlockModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity)
            : base(blockSpriteFactory)
        {
            //Initialize Texture first
            Texture = BlockSpriteFactory.GetBlockSprite("pipetop");

            CurrentState = new WarpPipeStandardState(this);
            CurrentState.Enter(null);
            //Define the characteristics of a pipe block here
            Position = coordinates;
            CurrentFrame = 0;
            Columns = 1;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            Velocity = velocity;


            //Enemies
            //EnemyModelFactory = enemyModelFactory;
            //NumOfEnemies = numOfEnemies;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

        }
        public override void CollisionResponseTop(ICollidable collidable)
        {
            base.CollisionResponseTop(collidable);
            //this is where he can go into the bonus level
        }


    }
}
