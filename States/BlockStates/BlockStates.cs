using Microsoft.Xna.Framework;
using Sprint_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States
{
    public abstract class BlockStates : IBlockStates
    {

        public IBlockStates PreviousState { get; set; }
        public BlockModel Block { get; set; }
        protected IBlockStates CurrentState { get { return Block.CurrentState; } set { Block.CurrentState = value; } }
        IBlockStates IBlockStates.PreviousState { get { return PreviousState; } }
        

        protected BlockStates(BlockModel block)
        {
            Block = block;
        }
        public virtual void Enter(IBlockStates previousState)
        {
            CurrentState = this;
            PreviousState = previousState;
        }

        //Only Implement these methods inside each class that inherits this class if applicable
        public virtual void BumpTransition() { }

        public virtual void ExitState() { }

        public virtual void ExplodedTransition() { }

        public virtual void StandardTransition(IBlockStates previousState) { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void UsedTransition() { }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
