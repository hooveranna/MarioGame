using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States
{
    public interface IBlockStates : IStates
    {
        void Update(GameTime gameTime);
        IBlockStates PreviousState { get; }
        void Enter(IBlockStates previousState);
        void ExitState();
        void StandardTransition(IBlockStates previousState);
        void UsedTransition();
        void ExplodedTransition();
        void BumpTransition();

    }
}
