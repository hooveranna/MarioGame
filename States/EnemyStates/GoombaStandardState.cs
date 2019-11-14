using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class GoombaStandardState : EnemyStates
    {
        public GoombaStandardState(EnemyModel enemy) : base(enemy)
        {
        }
        public override void Enter(IEnemyStates previousState)
        {
            Enemy.IsVisible = true;
            Enemy.LeftFacing = false;
            Enemy.IsAnimated = true;
            CurrentState = this;
            PreviousState = previousState;
            Enemy.Color = Color.White;
            //Injured variable is 1 for standardstate
            Enemy.InjuredVariable = 1;
            Enemy.TotalFrames = 2;
            Enemy.InjuredHeightFactor = 1;
            Enemy.InjuredPositionFactor = 0;
        }
        //If injured, changed SpriteEffects
        public override void InjuredTransition()
        {
            CurrentState.ExitState();
            CurrentState = new GoombaInjuredState(Enemy);
            CurrentState.Enter(this);
        }
    }
}
