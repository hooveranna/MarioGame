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
    class FireFlowerModel : ItemModel
    {

        Vector2 FixedPosition;
        CollisionGrid CollisionGrid;
        int ItemOutsideBlock = 0;
        public FireFlowerModel(ItemEnemySpriteFactory itemEnemySpriteFactory, Vector2 coordinates, Vector2 velocity,CollisionGrid collisionGrid)
            : base(itemEnemySpriteFactory)
        {

            Texture = ItemEnemySpriteFactory.GetItemSprite("fireflower");
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
            CollisionGrid = collisionGrid;
        }

        public override void Update(GameTime gameTime)
        {

            //Updating the item's bounce
            base.Update(gameTime);
            if (Math.Abs(Position.Y - FixedPosition.Y) >= 24)
            {
                Velocity = new Vector2(0, 0);
                //Add the item as a collidable
                ItemOutsideBlock++;
                if (ItemOutsideBlock == 1)
                {
                    CollisionGrid.AddCollidable(this);
                }

            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw based on how many 
            base.Draw(spriteBatch);

        }
        public override void Move(Vector2 blockPosition, bool marioLeftFacing)
        {
            //Update ItemVelocity
            Velocity = new Vector2(0, Velocity.Y - verticalV);
        }

    }
}
