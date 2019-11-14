using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States.Action_States
{
    class IdlingState : IActionState
    {
        private static IdlingState instance = null;
        public double HeightFactor { get; set; }
        public IdlingState()
        {
        }

        public static IdlingState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new IdlingState();
                    instance.HeightFactor = 1;
                }
                return instance;
            }
        }
        public IActionState Crouch(/*IPowerupState currentPowerUpState*/IMarioPowerupStates currentPowerupState)
        {
            if(currentPowerupState is MarioStandardState)
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
                return RunningState.Instance;
            }
            else
            {
                leftFacing = true;
                return this;
            }
        }

        public IActionState MoveRight(ref bool leftFacing)
        {
            if (leftFacing)
            {
                leftFacing = false;
                return this;
            }
            else
            {
                return RunningState.Instance;
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
