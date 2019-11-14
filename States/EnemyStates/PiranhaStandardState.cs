using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class PiranhaStandardState : EnemyStates
    {
        private Vector2 FixedPosition;
        public PiranhaStandardState(EnemyModel enemy) : base(enemy)
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
            FixedPosition = Enemy.Position;
        }
        //If injured, changed SpriteEffects
        public override void InjuredTransition()
        {
            CurrentState.ExitState();
            CurrentState = new PiranhaInjuredState(Enemy);
            CurrentState.Enter(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Make piranha go up and down.

            //Animation for bumped

            //Enemy.Velocity = new Vector2(0, Enemy.Velocity.Y - 10);
            if (Math.Abs(Enemy.Position.Y - FixedPosition.Y) > 20)
            {
                Enemy.Velocity = new Vector2(0, Enemy.Velocity.Y * -1);

            }
            else if (Math.Abs(Enemy.Position.Y - FixedPosition.Y) < -20)
            {
                Enemy.Velocity = new Vector2(0, Enemy.Velocity.Y * -1);
            }
        }

    }
}
