using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ParticleEngine2D;
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
    class BrickBlockWithItemModel : BlockModel
    {
        public int NumOfItems;
        public ItemModel ItemModel;
        ItemModelFactory ItemModelFactory;
        string ItemType;
        //CollisionGrid CollisionGrid;
        public BrickBlockWithItemModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity, ItemModelFactory itemModelFactory,string itemType, int numOfItems)
           : base(blockSpriteFactory)
        {
            //If the Brick block has an Item
            //Initialize state first
            CurrentState = new BrickBlockWithItemStandardState(this);
            CurrentState.Enter(null);

            IBlockStates previousState = CurrentState;
            CurrentState = new BlockHasItemState(this);
            CurrentState.Enter(previousState);
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

            //Particles
            Texture2D brickTexture = BlockSpriteFactory.GetBlockSprite("brick");
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(brickTexture);
            ParticleEngine = new ParticleEngine(textures, Position);

            //Items
            ItemModelFactory = itemModelFactory;
            NumOfItems = numOfItems;
            ItemType = itemType;
            //CollisionGrid = collisionGrid;
            ItemModel = itemModelFactory.GetItemModel(ItemType, coordinates,Velocity);
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
            
            base.Draw(spriteBatch);

            ParticleEngine.Draw(spriteBatch);



        }
        public override void CollisionResponseBottom(ICollidable collidable)
        {
            base.CollisionResponseBottom(collidable);

            if (collidable is MarioModel)
            {
                MarioModel marioModel = (MarioModel)collidable;
                if (NumOfItems > 0)
                {
                    //Add the item to the collision grid and move the item
                    ItemModel = ItemModelFactory.GetItemModel(ItemType, Position, Velocity);
                    //AddItemsButCoinAsCollidable();
                    ItemModel.Move(Position,marioModel.leftFacing);
                    //If items still exist inside brick, bump the brick.
                    this.CurrentState.BumpTransition();
                    NumOfItems--;
                    if(ItemModel is CoinModel)
                    {
                        marioModel.CollectCoin();
                    }

                }

            } 
            
        }
    }
}
