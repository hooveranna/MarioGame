using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States
{
    public interface IMarioPowerupStates : IStates
    {
        void Update(GameTime gameTime);
        IMarioPowerupStates PreviousState { get; }
        void Enter(IMarioPowerupStates previousState);
        void ExitState();

        //PowerUp transitions
        void StandardTransition(IMarioPowerupStates previousState);
        void SuperTransition(IMarioPowerupStates previousState);
        void FireTransition(IMarioPowerupStates previousState);
        void DamageTransition(IMarioPowerupStates previousState);

    }
}
