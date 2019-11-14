using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class QuestionBlockStandardState : BlockStates
    {
        Vector2 FixedPosition;
        public QuestionBlockStandardState(BlockModel block) : base(block)
        {
            Block.IsAnimated = true;
        }
        public override void Enter(IBlockStates previousState)
        {
            Block.IsAnimated = true;
            CurrentState = this;
            PreviousState = previousState;
            if (Block.Sprite != null)
            {
                FixedPosition = Block.Position;
            }

            Block.Texture = Block.BlockSpriteFactory.GetBlockSprite("question");
            Block.Position = FixedPosition;

        }

        public override void BumpTransition()
        {
            CurrentState.ExitState();
            CurrentState = new QuestionBlockBumpState(Block);
            CurrentState.Enter(this);
        }

    }
}
