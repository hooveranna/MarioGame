using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.Models.BlockModels;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class FlagPoleActivatedState : BlockStates
    {

        private int TicksToSkip = 2;
        private int TicksSinceLastUpdate;
        public FlagPoleActivatedState(BlockModel block) : base(block)
        {
        }
        public override void Enter(IBlockStates previousState)
        {
            Block.Time.Start();
            Block.IsAnimated = true;
            CurrentState = this;
            //Velocity that determines the blocks bump
            Block.CurrentFrame = 4;
            Block.IsAnimated = false;
            Block.TotalFrames = 5;
        }

        public override void Update(GameTime gameTime)
        {

            if (TicksSinceLastUpdate >= TicksToSkip)
            {
                if (Block.CurrentFrame <= 0)
                {
                    Block.IsAnimated = false;
                }
                else
                {
                    Block.CurrentFrame--;
                }
                TicksSinceLastUpdate = 0;
            }
            else
            {
                TicksSinceLastUpdate++;
            }
        }


    }
}
