using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Models;
using Sprint_4.Sprites;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class BlockHasItemState : BlockStates
    {
        public BlockHasItemState(BlockModel block) : base(block)
        {
        }

        //public BlockHasItemState(BlockModel block, ItemModel item) : base(block) => ItemModel = item;

        public override void Enter(IBlockStates previousState)
        {
            CurrentState = previousState;
        }

        public override void BumpTransition()
        {
            CurrentState.BumpTransition();
            ExitState();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Animate the item going up here.
        }

        public override void ExitState()
        {
            //Implement turning into used block here.
            CurrentState = new QuestionBlockBumpState(Block);
        }
    }
}
