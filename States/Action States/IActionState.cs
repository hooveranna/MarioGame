using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States.Action_States
{
    public interface IActionState : IStates
    {
        double HeightFactor { get; set; }
        IActionState MoveLeft(ref bool leftFacing);
        IActionState MoveRight(ref bool leftFacing);
        IActionState Jump();
        IActionState Crouch(/*IPowerupState currentPowerupState*/IMarioPowerupStates currentPowerupState);
        IActionState Fall();
        IActionState Leave();
    }
}
