using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States.Action_States
{
    public class CrouchingState : IActionState
    {
        private static CrouchingState instance = null;
        private CrouchingState()
        {
        }

        public IActionState prevState;

        public static CrouchingState Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CrouchingState();
                    instance.HeightFactor = 0.75;
                }
                return instance;
            }
        }

        public double HeightFactor { get; set; }
        public IActionState PrevState { get => prevState; set => prevState = value; }

        public IActionState Crouch(/*IPowerupState currentPowerupState*/IMarioPowerupStates currentPowerupState)
        {
            return this;
        }

        public IActionState Jump()
        {
            return this.PrevState;
        }

        public IActionState MoveLeft(ref bool leftFacing)
        {
            return Leave();
        }

        public IActionState MoveRight(ref bool leftFacing)
        {
            return Leave();
        }
        public IActionState Fall()
        {
            return FallingState.Instance;
        }
        public IActionState Leave()
        {
            return IdlingState.Instance;
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
