using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States.Action_States
{
    class RunningState : IActionState
    {
        private static RunningState instance = null;
        public double HeightFactor { get; set; }
        private RunningState()
        {
        }

        public static RunningState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RunningState();
                    instance.HeightFactor = 1;
                }
                return instance;
            }
        }
        public IActionState Crouch(/*IPowerupState currentPowerupState*/IMarioPowerupStates currentPowerupState)
        {
            if (currentPowerupState is MarioStandardState)
            {
                return this;
            }
            else
            {
                CrouchingState.Instance.PrevState = this;
                return CrouchingState.Instance;
            }
        }

        public IActionState Jump()
        {
            JumpingState.Instance.prevState = this;
            return JumpingState.Instance;
        }

        public IActionState MoveLeft(ref bool leftFacing)
        {
            if (leftFacing)
            {
                return this;
            }
            else
            {
                return IdlingState.Instance;
            }
        }

        public IActionState MoveRight(ref bool leftFacing)
        {
            if (leftFacing)
            {
                return IdlingState.Instance;
            }
            else
            {
                return this;
            }
        }
        public IActionState Fall()
        {
            return FallingState.Instance;
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
        public IActionState Leave()
        {
            throw new NotImplementedException();
        }
    }
}
