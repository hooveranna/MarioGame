using Sprint_4.Sprites;
using Sprint_4.States.Action_States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Commands
{
    class CrouchCommand : ICommand
    {
        MarioModel mario;

        public CrouchCommand(MarioModel mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Crouch();
        }
    }
    class StopCrouchCommand : ICommand
    {
        MarioModel mario;
        public StopCrouchCommand(MarioModel mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.StopCrouch();
        }
    }
    class FireCommand : ICommand
    {
        MarioModel receiver;

        public FireCommand(MarioModel receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.Fire();
        }
    }
    class JumpCommand : ICommand
    {
        MarioModel mario;
        public JumpCommand(MarioModel mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Jump();
        }
    }
    class StopJumpCommand : ICommand
    {
        MarioModel mario;
        public StopJumpCommand(MarioModel mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.UpdateJump(true);
        }
    }
    class MoveLeftCommand : ICommand
    {
        MarioModel mario;
        public MoveLeftCommand(MarioModel mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.MoveLeft();
        }
    }
    class StopLeftCommand : ICommand
    {
        MarioModel mario;
        public StopLeftCommand(MarioModel mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.StopLeft();
        }
    }
    class MoveRightCommand : ICommand
    {
        MarioModel mario;
        public MoveRightCommand(MarioModel mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.MoveRight();
        }
    }
    class StopRightCommand : ICommand
    {
        MarioModel mario;
        public StopRightCommand(MarioModel mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.StopRight();
        }
    }
    class StandardCommand : ICommand
    {
        MarioModel receiver;

        public StandardCommand(MarioModel receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.Standard();
        }
    }
    class SuperCommand : ICommand
    {
        MarioModel receiver;

        public SuperCommand(MarioModel receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.Super();
        }
    }
    class TakeDamageCommand : ICommand
    {
        MarioModel mario;
        public TakeDamageCommand(MarioModel mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.TakeDamage();
        }
    }

    class ToggleCrouchCommand : ICommand
    {
        MarioModel mario;
        public ToggleCrouchCommand(MarioModel mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.ToggleCrouchCommand();
        }
    }
    class ToggleGravityCommand : ICommand
    {
        MarioModel receiver;

        public ToggleGravityCommand(MarioModel receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.ToggleGravity();
        }
    }

    class ToSecretRoomCommand : ICommand
    {
        MarioModel receiver;

        public ToSecretRoomCommand(MarioModel receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.Velocity = new Microsoft.Xna.Framework.Vector2(0,-2);
            receiver.Position = new Microsoft.Xna.Framework.Vector2(60,1136);
        }
    }


    class ToTestRoomCommand : ICommand
    {
        MarioModel receiver;

        public ToTestRoomCommand(MarioModel receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.Velocity = new Microsoft.Xna.Framework.Vector2(0, -2);
            receiver.Position = new Microsoft.Xna.Framework.Vector2(3000, 1136);
        }
    }


    class GoToCastleCommand : ICommand
    {
        MarioModel receiver;

        public GoToCastleCommand (MarioModel receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.Velocity = new Microsoft.Xna.Framework.Vector2(1, 0);
            receiver.actionState = RunningState.Instance;
            //receiver.Position = new Microsoft.Xna.Framework.Vector2(5500, 600);
        }
    }
}
