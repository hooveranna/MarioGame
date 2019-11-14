﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States
{
    public interface IEnemyStates : IStates
    {
        void Update(GameTime gameTime);
        IEnemyStates PreviousState { get; }
        void Enter(IEnemyStates previousState);
        void ExitState();
        void StandardTransition();
        void InjuredTransition();
    }
}
