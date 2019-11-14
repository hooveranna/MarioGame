using Sprint_4.Models;

namespace Sprint_4.States
{
    class BrickBlockWithItemStandardState : BlockStates
    {
        public BrickBlockWithItemStandardState(BlockModel block) : base(block)
        {
            Block.IsAnimated = false;
        }
        public override void Enter(IBlockStates previousState)
        {
            Block.IsAnimated = false;
            CurrentState = this;
            PreviousState = previousState;

            Block.Texture = Block.BlockSpriteFactory.GetBlockSprite("brick");
        }

        public override void BumpTransition()
        {
            CurrentState.ExitState();
            CurrentState = new BrickBlockWithItemBumpState(Block);
            CurrentState.Enter(this);
        }
    }
}
