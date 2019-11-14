using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.Sprites;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class MarioStandardState : MarioPowerupStatesAbstract
    {
        public MarioStandardState(MarioModel mario) : base(mario)
        {
        }
        public override void Enter(IMarioPowerupStates previousState)
        {
            //Initialize state variables
            Mario.MarioHeightFactor = 0.5;
            Mario.DeadPositionFactor = 1;

            //Initialize states
            CurrentState = this;
            PreviousState = previousState;
        }
        /*public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Enter(this);
        }*/

        //All the transitions here
        public override void DamageTransition(IMarioPowerupStates previousState)
        {
            CurrentState.ExitState();
            CurrentState = new MarioDeadState(Mario);
            CurrentState.Enter(this);
        }

        public override void FireTransition(IMarioPowerupStates previousState)
        {
            CurrentState.ExitState();
            CurrentState = new MarioFireState(Mario);
            CurrentState.Enter(this);
            Mario.Position = new Vector2(Mario.Position.X, Mario.Position.Y - 24);

        }

        public override void SuperTransition(IMarioPowerupStates previousState)
        {
            CurrentState.ExitState();
            CurrentState = new MarioSuperState(Mario);
            CurrentState.Enter(this);
            Mario.Position = new Vector2(Mario.Position.X, Mario.Position.Y - 24);
        }
    }
}
