using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.Models.BlockModels;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class FlagPoleStandardState : BlockStates
    {
        public FlagPoleStandardState(BlockModel block) : base(block)
        {
        }
        public override void Enter(IBlockStates previousState)
        {
            Block.IsAnimated = false;
            CurrentState = this;
            PreviousState = previousState;
            Block.Texture = Block.BlockSpriteFactory.GetBlockSprite("flag");
            Block.CurrentFrame = 4;
            Block.TotalFrames = 5;

        }
        public override void BumpTransition()
        {
            CurrentState.ExitState();
            CurrentState = new FlagPoleActivatedState(Block);
            CurrentState.Enter(this);
        }
        public override void ExplodedTransition()
        {
            BumpTransition();
        }

    }
}
