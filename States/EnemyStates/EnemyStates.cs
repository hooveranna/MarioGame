using Microsoft.Xna.Framework;
using Sprint_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States
{
    public abstract class EnemyStates : IEnemyStates
    {

        public IEnemyStates PreviousState { get; set; }
        public EnemyModel Enemy { get; set; }
        public IEnemyStates CurrentState { get { return Enemy.CurrentState; } set { Enemy.CurrentState = value; } }
        IEnemyStates IEnemyStates.PreviousState { get { return PreviousState; } }

        protected EnemyStates(EnemyModel enemy)
        {
            Enemy = enemy;
        }
        public virtual void Enter(IEnemyStates previousState)
        {
            CurrentState = this;
            PreviousState = previousState;
        }

        //Only Implement these methods inside each class that inherits this class if applicable
        public virtual void ExitState() { }

        public virtual void StandardTransition() { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void InjuredTransition() { }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
