using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States.Action_States
{
    class FallingState : IActionState
    {
        private static FallingState instance = null;
        public double HeightFactor { get; set; }
        public FallingState()
        {
        }

        public static FallingState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FallingState();
                    instance.HeightFactor = 1;
                }
                return instance;
            }
        }

        public IActionState Crouch(/*IPowerupState currentPowerupState*/IMarioPowerupStates currentPowerupState)
        {
            return Leave();
        }

        public IActionState Jump()
        {
            //I'm not sure if you can jump out of a fall
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
            return this;
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
        public IActionState Leave()
        {
            return IdlingState.Instance;
        }

    }
}
