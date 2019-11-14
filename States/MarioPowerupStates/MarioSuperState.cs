using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.Sprites;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class MarioSuperState : MarioPowerupStatesAbstract
    {
        public MarioSuperState(MarioModel mario) : base(mario)
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
            CurrentState = new MarioStandardState(Mario);
            CurrentState.Enter(this);
            Mario.Position = new Vector2(Mario.Position.X, Mario.Position.Y + 24);
        }

        public override void FireTransition(IMarioPowerupStates previousState)
        {
            CurrentState.ExitState();
            CurrentState = new MarioFireState(Mario);
            CurrentState.Enter(this);
        }

        //This transition is only kept for the cheat commands Yy
        public override void StandardTransition(IMarioPowerupStates previousState)
        {
            DamageTransition(this);
        }

    }
}
