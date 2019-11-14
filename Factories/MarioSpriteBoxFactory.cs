using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.States;
using Sprint_4.States.Action_States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Factories
{
    public class MarioSpriteBoxFactory
    {
        private Texture2D dead; //dead :(

        private Texture2D standardIdling;
        private Texture2D standardJumping;
        private List<Texture2D> standardRunning;
        private Texture2D standardFalling;
        private Texture2D standardCrouching;

        private Texture2D superIdling;
        private Texture2D superJumping;
        private List<Texture2D> superRunning;
        private Texture2D superFalling;
        private Texture2D superCrouching;

        private Texture2D fireIdling;
        private Texture2D fireJumping;
        private List<Texture2D> fireRunning;
        private Texture2D fireFalling;
        private Texture2D fireCrouching;

        public MarioSpriteBoxFactory(Texture2D dead, Texture2D standardIdling, Texture2D standardJumping, List<Texture2D> standardRunning, Texture2D standardFalling, Texture2D standardCrouching, Texture2D superIdling, Texture2D superJumping, List<Texture2D> superRunning, Texture2D superFalling, Texture2D superCrouching, Texture2D fireIdling, Texture2D fireJumping, List<Texture2D> fireRunning, Texture2D fireFalling, Texture2D fireCrouching)
        {
            this.dead = dead;
            this.standardIdling = standardIdling;
            this.standardJumping = standardJumping;
            this.standardRunning = standardRunning;
            this.standardFalling = standardFalling;
            this.standardCrouching = standardCrouching;
            this.superIdling = superIdling;
            this.superJumping = superJumping;
            this.superRunning = superRunning;
            this.superFalling = superFalling;
            this.superCrouching = superCrouching;
            this.fireIdling = fireIdling;
            this.fireJumping = fireJumping;
            this.fireRunning = fireRunning;
            this.fireFalling = fireFalling;
            this.fireCrouching = fireCrouching;
        }

        public Texture2D GetSprite(IActionState actionState, IMarioPowerupStates powerUpState, GameTime gameTime)
        {
            if (powerUpState is MarioDeadState)
            {
                //dead :(
                return this.dead;
            }
            else if (powerUpState is MarioStandardState)
            {
                if(actionState is IdlingState)
                {
                    //standard idling
                    return this.standardIdling;
                }
                else if(actionState is JumpingState)
                {
                    //standard jumping
                    return this.standardJumping;
                }
                else if (actionState is FallingState)
                {
                    //standard falling
                    return this.standardFalling;
                }
                else if (actionState is RunningState)
                {
                    //standard running
                    //animate
                    int animationIntervalTicks = 2000000;
                    long animationFrame = gameTime.TotalGameTime.Ticks / animationIntervalTicks;
                    int animationIndex = (int) (animationFrame % standardRunning.Count);
                    return this.standardRunning[animationIndex];
                }
                else if (actionState is CrouchingState)
                {
                    //standard crouching
                    return this.standardCrouching;
                }

            }
            else if (powerUpState is MarioSuperState)
            {
                if (actionState is IdlingState)
                {
                    //super idling
                    return this.superIdling;
                }
                else if (actionState is JumpingState)
                {
                    //super jumping
                    return this.superJumping;
                }
                else if (actionState is FallingState)
                {
                    //super falling
                    return this.superFalling;
                }
                else if (actionState is RunningState)
                {
                    //super running
                    //animate
                    int animationIntervalTicks = 2000000;
                    long animationFrame = gameTime.TotalGameTime.Ticks / animationIntervalTicks;
                    int animationIndex = (int)(animationFrame % superRunning.Count);
                    return this.superRunning[animationIndex];
                }
                else if (actionState is CrouchingState)
                {
                    //super crouching
                    return this.superCrouching;
                }

            }
            else if (powerUpState is MarioFireState)
            {
                if (actionState is IdlingState)
                {
                    //fire idling
                    return this.fireIdling;
                }
                else if (actionState is JumpingState)
                {
                    //fire jumping
                    return this.fireJumping;
                }
                else if (actionState is FallingState)
                {
                    //fire falling
                    return this.fireFalling;
                }
                else if (actionState is RunningState)
                {
                    //animate
                    int animationIntervalTicks = 2000000;
                    long animationFrame = gameTime.TotalGameTime.Ticks / animationIntervalTicks;
                    int animationIndex = (int)(animationFrame % fireRunning.Count);
                    return this.fireRunning[animationIndex];
                }
                else if (actionState is CrouchingState)
                {
                    //fire crouching
                    return this.fireCrouching;
                }

            }
            return null;
        }
        
    }
}
