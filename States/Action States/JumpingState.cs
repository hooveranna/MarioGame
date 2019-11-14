using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States.Action_States
{
    class JumpingState : IActionState

    {
        private static JumpingState instance = null;
        public double HeightFactor { get; set; }

        public IActionState prevState;
        private JumpingState()
        {
        }

        public static JumpingState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JumpingState();
                    instance.HeightFactor = 1;
                }
                return instance;
            }
        }
        public IActionState Crouch(/*IPowerupState currentPowerupState*/IMarioPowerupStates currentPowerupState)
        {
            return this.prevState;
        }

        public IActionState Jump()
        {
            return this;
        }

        public IActionState MoveLeft(ref bool leftFacing)
        {
            //leftFacing = true;
            return this;
        }

        public IActionState MoveRight(ref bool leftFacing)
        {
            //leftFacing = false;
            return this;
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
            return new FallingState();
        }
    }
}
