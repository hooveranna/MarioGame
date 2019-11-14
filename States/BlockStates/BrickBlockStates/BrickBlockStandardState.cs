using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class BrickBlockStandardState : BlockStates
    {
        public BrickBlockStandardState(BlockModel block) : base(block)
        {
            Block.IsAnimated = false;
        }
        public override void Enter(IBlockStates previousState)
        {
            Block.IsAnimated = false;
            CurrentState = this;
            PreviousState = previousState;

            //Block.Texture = Block.BlockSpriteFactory.GetBlockSprite(CurrentState, "brick");
        }

        public override void BumpTransition()
        {
            CurrentState.ExitState();
            CurrentState = new BrickBlockBumpState(Block);
            CurrentState.Enter(this);
        }

        public override void ExplodedTransition()
        {
            CurrentState.ExitState();
            CurrentState = new BrickBlockExplodedState(Block);
        }
    }
}
