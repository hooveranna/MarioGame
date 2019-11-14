using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States
{
    public interface IItemStates : IStates
    {
        void Update(GameTime gameTime);
        IItemStates PreviousState { get; }
        void Enter(IItemStates previousState);
        void ExitState();
        void StandardTransition();
        void ConsumedTransition();
    }
}
