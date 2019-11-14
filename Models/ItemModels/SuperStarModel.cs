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
using System.Diagnostics;

namespace Sprint_4.Models
{
    class SuperStarModel : ItemModel
    {

        Vector2 FixedPosition;
        bool OutOfBlock;
        CollisionGrid CollisionGrid;
        int ItemOutsideBlock;
        bool LeftFacing = false;
        public SuperStarModel(ItemEnemySpriteFactory itemEnemySpriteFactory, Vector2 coordinates, Vector2 velocity, CollisionGrid collisionGrid)
            : base(itemEnemySpriteFactory)
        {

            Texture = ItemEnemySpriteFactory.GetItemSprite("star");
            //Initialize state first
            CurrentState = new ItemStandardState(this);
            CurrentState.Enter(null);

            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            //If additional frames of QuestionBlocks are added, update Columns
            Columns = 4;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            TotalFrames = 4;
            Velocity = velocity;


            //Bump Animation variables
            FixedPosition = Position;
            horizontalV = 2;
            //MoveAwayFactor = new Vector2(-100, -50);
            OutOfBlock = false;
            CollisionGrid = collisionGrid;
        }

        public override void Update(GameTime gameTime)
        {
            //Updating the item's bounce
            base.Update(gameTime);
            if (Math.Abs(Position.Y - FixedPosition.Y) >= 40)
            {
                OutOfBlock = true;
                MoveAway();
                CanGravity = true;

                //Add the item as a collidable
                ItemOutsideBlock++;
                if (ItemOutsideBlock == 1)
                {
                    CollisionGrid.AddCollidable(this);
                }
            }
            if (OutOfBlock)
            {
                if (Math.Abs(Position.Y - FixedPosition.Y) >= 40)
                {
                    CanGravity = true;
                }
            }
            ////This is making Star jump Up and down
            //if (Math.Abs(Position.Y - FixedPosition.Y) >= 50)
            //{
            //    MoveAwayFactor = new Vector2(MoveAwayFactor.X, MoveAwayFactor.Y * -1);
            //}
            //MoveAway();
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

            //Item moves away from mario based on where he is facing
            //Gravity must be used here to stop or keep the item's fall
            //Update ItemVelocity
            if (LeftFacing)
            {
                //Update ItemVelocity
                //Velocity = new Vector2(horizontalV, Velocity.Y);

                Velocity = new Vector2(horizontalV, Velocity.Y);
            }
            else
            {
                //Velocity = new Vector2(-horizontalV, Velocity.Y);

                Velocity = new Vector2(- horizontalV, Velocity.Y);
            }
            CanGravity = true;
            //Support = false;
        }
        //public override void Gravity(bool onSomething)
        //{
        //    if (onSomething && FixedPosition.Y < Position.Y)
        //    {
        //        CanGravity = false;
        //        Velocity = new Vector2(Velocity.X, MoveAwayFactor.Y);
        //    }
        //    if (!onSomething)
        //    {
        //        Velocity = new Vector2(this.Velocity.X, 50);
        //    }
        //}
    }
}
