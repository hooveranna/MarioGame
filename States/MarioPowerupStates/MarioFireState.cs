using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.Sprites;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class MarioFireState : MarioPowerupStatesAbstract
    {
        public MarioFireState(MarioModel mario) : base(mario)
        {
        }
        public override void Enter(IMarioPowerupStates previousState)
        {
            //Initialize state variables
            Mario.MarioHeightFactor = 1;
            Mario.DeadPositionFactor = 1;

            //Initialize states
            CurrentState = this;
            PreviousState = previousState;
        }

        //All the transitions here
        public override void DamageTransition(IMarioPowerupStates previousState)
        {
            CurrentState.ExitState();
            CurrentState = new MarioSuperState(Mario);
            CurrentState.Enter(this);
        }
        //These two transitions are only kept for the cheat commands Yy and Uu
        public override void StandardTransition(IMarioPowerupStates previousState)
        {
            CurrentState.ExitState();
            CurrentState = new MarioStandardState(Mario);
            CurrentState.Enter(this);
            Mario.Position = new Vector2(Mario.Position.X,Mario.Position.Y+24);
        }

        public override void SuperTransition(IMarioPowerupStates previousState)
        {
            DamageTransition(this);
        }
    }
}
