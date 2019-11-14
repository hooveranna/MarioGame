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
    class WarpPipeEnemyModel : BlockModel
    {
        int NumOfEnemies;
        public EnemyModel EnemyModel;
        //EnemyModelFactory EnemyModelFactory;
        string EnemyType;
        CollisionGrid CollisionGrid;
        EnemyModelFactory EnemyModelFactory;
        public WarpPipeEnemyModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity, EnemyModelFactory enemyModelFactory, string enemyType,int numOfEnemies, CollisionGrid collisionGrid)
            : base(blockSpriteFactory)
        {

            //Constructor for warppipe that hides enemies
            //Initialize Texture first
            Texture = BlockSpriteFactory.GetBlockSprite("pipetop");

            CurrentState = new WarpPipeEntityStandardState(this);
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
            EnemyModelFactory = enemyModelFactory;
            EnemyType = enemyType;
            CollisionGrid = collisionGrid;
            EnemyModel = enemyModelFactory.GetEnemyModel(enemyType, coordinates, Velocity);
            EnemyModel.IsVisible = false;
            NumOfEnemies = numOfEnemies;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            EnemyModel.Update(gameTime);
            //ItemMovement
            if (HasStartedMoving == 1)
            {
                //Only move left ONCE.
                HasStartedMoving++;
                if (NumOfEnemies> 0)
                {
                    //Add the item to the collision grid and move the item
                    EnemyModel = EnemyModelFactory.GetEnemyModel(EnemyType, Position, Velocity);
                    //EnemyModel.Move(Position, false);
                    EnemyModel.IsVisible = true;
                    CollisionGrid.AddCollidable(EnemyModel);
                    //If items still exist inside brick, bump the brick.
                    CurrentState.ExplodedTransition();
                    NumOfEnemies--;

                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            EnemyModel.Draw(spriteBatch);

        }
        public override void CollisionResponseTop(ICollidable collidable)
        {
            base.CollisionResponseTop(collidable);
            //this is where he can go into the bonus level
        }

        public void ShowElements(ICollidable collidable)
        {

            if (collidable is MarioModel marioModel)
            {
                if (NumOfEnemies > 0)
                {
                    //Add the item to the collision grid and move the item
                    EnemyModel = EnemyModelFactory.GetEnemyModel(EnemyType, Position, Velocity);
                    CollisionGrid.AddCollidable(EnemyModel);
                    //EnemyModel.MoveOut(Position, marioModel.leftFacing);
                    //If items still exist inside brick, bump the brick.
                    CurrentState.ExplodedTransition();
                    NumOfEnemies--;

                }
            }

        }

    }
}
