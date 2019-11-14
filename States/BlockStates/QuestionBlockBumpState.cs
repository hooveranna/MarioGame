using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.Models.BlockModels;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class QuestionBlockBumpState : BlockStates
    {

        private Vector2 FixedPosition;
        private readonly int SpeedY = 60;
        public QuestionBlockBumpState(BlockModel block) : base(block)
        {
        }
        public override void Enter(IBlockStates previousState)
        {
           
            FixedPosition = Block.Position;
            CurrentState = this;
            //Velocity that determines the blocks bump
            Block.Velocity = new Vector2(0, -SpeedY);
            Block.Texture = Block.BlockSpriteFactory.GetBlockSprite("used");
            Block.CurrentFrame = 0;
            Block.IsAnimated = false;
            Block.TotalFrames = 1;
        }

        public override void ExitState()
        {
            Block.Position = FixedPosition;
            Block.Velocity = new Vector2(0, 0);
        }

        public override void Update(GameTime gameTime)
        {
            //Animation for bumped
            if (Math.Abs(Block.Position.Y - FixedPosition.Y) > 10)
            {
                Block.Velocity = new Vector2(0, Block.Velocity.Y * -1);
            }
            else if (Math.Abs(Block.Position.Y - FixedPosition.Y) == 0)
            {
                ExitState();
            }
        }
      

    }
}
