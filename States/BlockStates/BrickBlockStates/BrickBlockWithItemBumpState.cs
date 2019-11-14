using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.Models.BlockModels;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class BrickBlockWithItemBumpState : BlockStates
    {
        private Vector2 FixedPosition;
        private int SpeedY = 60;
        public BrickBlockWithItemBumpState(BlockModel block) : base(block)
        {
        }
        public override void Enter(IBlockStates previousState)
        {
            CurrentState = this;
            PreviousState = previousState;
            FixedPosition = Block.Position;

            //Velocity that determines the blocks bump
            Block.Velocity = new Vector2(0, -SpeedY);
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
                StandardTransition(PreviousState);
            }

            
        }
        public override void StandardTransition(IBlockStates previousState)
        {
            CurrentState.ExitState();
            CurrentState = previousState;
            CurrentState.Enter(this);

        }

    }
}
