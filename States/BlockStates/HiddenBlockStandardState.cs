using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.Models.BlockModels;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class HiddenBlockStandardState : BlockStates
    {
        public HiddenBlockStandardState(BlockModel block) : base(block)
        {
        }
        public override void Enter(IBlockStates previousState)
        {
            Block.IsAnimated = false;
            CurrentState = this;
            PreviousState = previousState;
            Block.Texture = Block.BlockSpriteFactory.GetBlockSprite("hidden");

        }
        public override void BumpTransition()
        {
            CurrentState = new BrickBlockWithItemStandardState(Block);
            CurrentState.Enter(this);
            CurrentState.BumpTransition();
        }
        public override void ExplodedTransition()
        {
            BumpTransition();
        }

    }
}
