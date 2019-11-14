using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.States;
using System;
using System.Diagnostics;
using System.Threading;

namespace Sprint_4.States
{
    class GoombaInjuredState : EnemyStates
    {

        public GoombaInjuredState(EnemyModel enemy) : base(enemy)
        {
        }
        public override void Enter(IEnemyStates previousState)
        {
            Enemy.Time.Start();
            Enemy.IsAnimated = false;
            CurrentState = this;
            PreviousState = previousState;
            //Injured variable is 1 for standardstate
            Enemy.InjuredVariable = 0;
            Enemy.TotalFrames = 3;
            Enemy.CurrentFrame = 2;
            Enemy.InjuredHeightFactor = 0.60f;
            //Send the collision box position so far off the screen that it is like turning of collision.
            Enemy.Velocity = new Vector2(0,0);
        }

    }
}
