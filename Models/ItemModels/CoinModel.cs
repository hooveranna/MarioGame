using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    class CoinModel : ItemModel
    {

        private Vector2 FixedPosition;
        int SpeedY = 6;
        bool ItemGoingUp;
        public CoinModel(ItemEnemySpriteFactory itemEnemySpriteFactory, Vector2 coordinates, Vector2 velocity)
            : base(itemEnemySpriteFactory)
        {

            Texture = ItemEnemySpriteFactory.GetItemSprite("coin");
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
            ItemGoingUp = true;
        }
        public CoinModel(ItemEnemySpriteFactory itemEnemySpriteFactory, Vector2 coordinates, Vector2 velocity, String type)
            : base(itemEnemySpriteFactory)
        {
            Texture = ItemEnemySpriteFactory.GetItemSprite("coinstatic");
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
            ItemGoingUp = false;
            Debug.WriteLine(type);
        }

        public override void Update(GameTime gameTime)
        {
            //Updating the item's bounce
            base.Update(gameTime);
            if (Math.Abs(Position.Y - FixedPosition.Y) > 80 && ItemGoingUp)
            {
                Velocity = new Vector2(0, Velocity.Y * -1);
                ItemGoingUp = false;
            }
            else if (Math.Abs(Position.Y - FixedPosition.Y) == 0 && !ItemGoingUp)
            {
                Velocity = new Vector2(0, 0);
                ItemGoingUp = true;
                
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw based on how many 
            base.Draw(spriteBatch);

        }
        public override void Move(Vector2 blockPosition, bool marioLeftFacing)
        {
            //Center the coin
            Position = new Vector2(blockPosition.X+5, blockPosition.Y);
            //Update ItemVelocity
            Velocity = new Vector2(0, Velocity.Y - SpeedY);
        }
    }
}
