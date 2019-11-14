using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States
{
    public abstract class MarioPowerupStatesAbstract : IMarioPowerupStates
    {

        protected MarioModel Mario { get; set; }
        protected IMarioPowerupStates PreviousState { get; set; }
        protected IMarioPowerupStates CurrentState { get { return Mario.CurrentPowerupState; } set { Mario.CurrentPowerupState = value; } }
        IMarioPowerupStates IMarioPowerupStates.PreviousState { get { return PreviousState; } }

        public MarioPowerupStatesAbstract(MarioModel mario)
        {
            Mario = mario;
        }

        public virtual void Enter(IMarioPowerupStates previousState)
        {
            CurrentState = this;
            PreviousState = previousState;
        }

        public virtual void ExitState()
        {}
        public virtual void DamageTransition(IMarioPowerupStates previousState)
        {}

        public virtual void FireTransition(IMarioPowerupStates previousState)
        {}

        public virtual void StandardTransition(IMarioPowerupStates previousState)
        {}

        public virtual void SuperTransition(IMarioPowerupStates previousState)
        {}

        public virtual void Update(GameTime gameTime)
        {}

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
