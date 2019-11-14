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

namespace Sprint_4.Models
{
    class RedMushroomModel : ItemModel
    {
        Vector2 FixedPosition;
        CollisionGrid CollisionGrid;
        int ItemOutsideBlock=0;
        bool LeftFacing = false;
        public RedMushroomModel(ItemEnemySpriteFactory itemEnemySpriteFactory, Vector2 coordinates, Vector2 velocity, CollisionGrid collisionGrid)
            : base(itemEnemySpriteFactory)
        {

            Texture = ItemEnemySpriteFactory.GetItemSprite("redmushroom");
            //Initialize state first
            CurrentState = new ItemStandardState(this);
            IsAnimated = false;
            CurrentState.Enter(null);

            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            //If additional frames of QuestionBlocks are added, update Columns
            Columns = 1;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            TotalFrames = 1;
            Velocity = velocity;
            //Bump Animation variables
            FixedPosition = Position;
            horizontalV = 1;
            //MoveAwayFactor = new Vector2(-50,0);
            CollisionGrid =  collisionGrid;
        }

        public override void Update(GameTime gameTime)
        {
            //Updating the item's bounce
            base.Update(gameTime);
            if (Math.Abs(Position.Y - FixedPosition.Y) >= 24)
            {
                //Velocity = new Vector2(0, 0);
                //After fully appearing, move away
                MoveAway();
                //Add the item as a collidable
                ItemOutsideBlock++;
                if (ItemOutsideBlock == 1)
                {
                    CollisionGrid.AddCollidable(this);
                }
            }
            if (CanGravity)
            {
                Gravity(Support);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw based on how many 
            base.Draw(spriteBatch);

        }
        public override void Move(Vector2 blockPosition, bool marioLeftFacing)
        {
            LeftFacing = marioLeftFacing;
            //Update ItemVelocity
            Velocity = new Vector2(Velocity.X, Velocity.Y - verticalV);
        }

        public void MoveAway()
        {
            //Item moves away towards mario based on where he is facing
            //Gravity must be used here to stop or keep the item's fall
            //Update ItemVelocity
            if (LeftFacing)
            {
                //Update ItemVelocity
                Velocity = new Vector2(-horizontalV, Velocity.Y);
            }
            else
            {
                Velocity = new Vector2(horizontalV, Velocity.Y);
            }

            CanGravity = true;
        }

    }
}
