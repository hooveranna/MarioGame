using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class WarpPipeEntityStandardState : BlockStates
    {
        public WarpPipeEntityStandardState(BlockModel block) : base(block)
        {
        }
        public override void Enter(IBlockStates previousState)
        {
            Block.IsAnimated = false;
            CurrentState = this;
            PreviousState = previousState;

        }

        public override void ExplodedTransition()
        {
            CurrentState.ExitState();
            CurrentState = new WarpPipeRevealContentsState(Block);
            CurrentState.Enter(this);
        }
    }
}
