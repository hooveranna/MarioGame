using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.Models.BlockModels;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class WarpPipeTeleportState : BlockStates
    {
        
        public WarpPipeTeleportState(BlockModel block) : base(block)
        {
        }
        public override void Enter(IBlockStates previousState)
        {
            CurrentState = this;
            Block.IsAnimated = false;
            //Pipe itself cannot teleport mario. mario must manually do that as of now
        }




    }
}
