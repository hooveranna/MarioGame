using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.Sprites;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class MarioDeadState : MarioPowerupStatesAbstract
    {
        public MarioDeadState(MarioModel mario) : base(mario)
        {
        }
        public override void Enter(IMarioPowerupStates previousState)
        {
            //Initialize state variables
            Mario.MarioHeightFactor = 0.5;
            Mario.DeadPositionFactor = 0;

            //Initialize states
            CurrentState = this;
            PreviousState = previousState;
        }

        public override void ExitState()
        {
            //For about 3 seconds, Disable the controls, make mario slowly fall down, play the dead sound, and restart the level
        }

        //Dead state cannot have any transitions
    }
}
