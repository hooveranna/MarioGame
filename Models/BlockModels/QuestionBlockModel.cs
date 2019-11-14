using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Collision;
using Sprint_4.Sprites;
using Sprint_4.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Models.BlockModels
{
    class QuestionBlockModel : BlockModel
    {
        public int NumOfItems;
        public ItemModel ItemModel;
        ItemModelFactory ItemModelFactory;
        string ItemType;
        //CollisionGrid CollisionGrid;
        public QuestionBlockModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity, ItemModelFactory itemModelFactory, string itemType, int numOfItems)
            : base(blockSpriteFactory)
        {
            //Initialize state first
            CurrentState = new QuestionBlockStandardState(this);
            CurrentState.Enter(null);

            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            //If additional frames of QuestionBlocks are added, update Columns
            Columns = 3;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            TotalFrames = 3;
            Velocity = velocity;

            //Items
            ItemModelFactory = itemModelFactory;
            NumOfItems = numOfItems;
            ItemType = itemType;
            ItemModel = itemModelFactory.GetItemModel(ItemType, coordinates, velocity);
            //CollisionGrid = collisionGrid;
            ItemModel.IsVisible = false;
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            ItemModel.Update(gameTime);

            if (NumOfItems == 0)
            {
                //Otherwise turn the brick into used block.
                Texture = BlockSpriteFactory.GetBlockSprite("used");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            ItemModel.Draw(spriteBatch);
            //Draw based on how many 
            base.Draw(spriteBatch);

        }
        public override void CollisionResponseBottom(ICollidable collidable)
        {
            base.CollisionResponseBottom(collidable);
            if (collidable is MarioModel)
            {
                MarioModel marioModel = (MarioModel)collidable;
                if (NumOfItems > 0)
                {
                    //Move the item
                    ItemModel = ItemModelFactory.GetItemModel(ItemType, Position, Velocity);
                    ItemModel.Move(Position, marioModel.leftFacing);
                    //If items still exist inside brick, bump the brick.
                    this.CurrentState.BumpTransition();
                    //AddItemsButCoinAsCollidable();
                    NumOfItems--;

                    if(ItemModel is CoinModel)
                    {
                        marioModel.CollectCoin();
                    }

                }
            }
        }

        //public void AddItemsButCoinAsCollidable()
        //{
        //    if (!ItemType.Equals("coin"))
        //    {
        //        CollisionGrid.AddCollidable(ItemModel);
        //    }
        //}

    }
}
