using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ParticleEngine2D;
using Sprint_4.Models;
using Sprint_4.States;
using System;
using System.Collections.Generic;

namespace Sprint_4.States
{
    class BrickBlockExplodedState : BlockStates
    {
        private int SpeedY = 20;
        public BrickBlockExplodedState(BlockModel block) : base(block)
        {
        }
        public override void Enter(IBlockStates previousState)
        {
            CurrentState = this;
            PreviousState = previousState;

            //Velocity that determines the blocks Explosion
            Block.Velocity = new Vector2(0, SpeedY);
        }
        public override void Update(GameTime gameTime)
        {
            Block.Time.Start();
            Block.Scale = new Vector2(1, 1);
            //Only update Particles during explosion
            Block.ParticleEngine.EmitterLocation = new Vector2(Block.Position.X+10, Block.Position.Y);
            Block.ParticleEngine.Update(Block.Scale.X);
            Block.ParticleEngine.Update(Block.Scale.Y);
            //Animation for exploded
            Block.Velocity = new Vector2(Block.Velocity.X,Block.Velocity.Y+5);
            //Block.Position.Y += 5;
            Block.Rotation += 2;
        }



    }
}
