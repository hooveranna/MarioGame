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
    class WarpPipeItemModel : BlockModel
    {
        public int NumOfItems;
        public ItemModel ItemModel;
        ItemModelFactory ItemModelFactory;
        string ItemType;
        CollisionGrid CollisionGrid;
        public WarpPipeItemModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity, ItemModelFactory itemModelFactory, string itemType, int numOfItems, CollisionGrid collisionGrid)
          : base(blockSpriteFactory)
        {
            //Constructor for warppipe that hides items
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

            //Items
            ItemModelFactory = itemModelFactory;
            NumOfItems = numOfItems;
            ItemType = itemType;
            CollisionGrid = collisionGrid;
            ItemModel = itemModelFactory.GetItemModel(ItemType, coordinates, Velocity);
            ItemModel.IsVisible = false;

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ItemModel.Update(gameTime);

            //ItemMovement
            if (HasStartedMoving == 1)
            {
                //Only move left ONCE.
                HasStartedMoving++;
                if (NumOfItems > 0)
                {
                    //Add the item to the collision grid and move the item
                    ItemModel = ItemModelFactory.GetItemModel(ItemType, Position, Velocity);
                    AddItemsButCoinAsCollidable();
                    ItemModel.Move(Position, false);
                    //If items still exist inside brick, bump the brick.
                    CurrentState.ExplodedTransition();
                    NumOfItems--;

                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            ItemModel.Draw(spriteBatch);

            base.Draw(spriteBatch);

        }
        public override void CollisionResponseTop(ICollidable collidable)
        {
            base.CollisionResponseTop(collidable);
            //this is where he can go into the bonus level
            /*
            if (collidable is MarioModel)
            {
                MarioModel marioModel = (MarioModel)collidable;
                if (NumOfItems > 0)
                {
                    //Add the item to the collision grid and move the item
                    ItemModel = ItemModelFactory.GetItemModel(ItemType, Position, Velocity);
                    AddItemsButCoinAsCollidable();
                    ItemModel.Move(Position, marioModel.leftFacing);
                    //If items still exist inside brick, bump the brick.
                    CurrentState.ExplodedTransition();
                    NumOfItems--;

                }
            }*/
        }

        public void AddItemsButCoinAsCollidable()
        {
            if (!ItemType.Equals("coin"))
            {
                CollisionGrid.AddCollidable(ItemModel);
            }
        }

    }
}
