using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Sprint_4.States;
using Sprint_4.States.Action_States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sprint_4.Factories
{
    public class MarioSpriteFactory
    {
        private Texture2D Dead; //dead :(

        private Texture2D StandardIdling;
        private Texture2D StandardJumping;
        private List<Texture2D> StandardRunning;
        private Texture2D StandardFalling;
        private Texture2D StandardCrouching;

        private Texture2D SuperIdling;
        private Texture2D SuperJumping;
        private List<Texture2D> SuperRunning;
        private Texture2D SuperFalling;
        private Texture2D SuperCrouching;

        private Texture2D FireIdling;
        private Texture2D FireJumping;
        private List<Texture2D> FireRunning;
        private Texture2D FireFalling;
        private Texture2D FireCrouching;

        public MarioSpriteFactory(Texture2D dead, Texture2D standardIdling, Texture2D standardJumping, List<Texture2D> standardRunning, Texture2D standardFalling, Texture2D standardCrouching, Texture2D superIdling, Texture2D superJumping, List<Texture2D> superRunning, Texture2D superFalling, Texture2D superCrouching, Texture2D fireIdling, Texture2D fireJumping, List<Texture2D> fireRunning, Texture2D fireFalling, Texture2D fireCrouching)
        {
            Dead = dead;
            StandardIdling = standardIdling;
            StandardJumping = standardJumping;
            StandardRunning = standardRunning;
            StandardFalling = standardFalling;
            StandardCrouching = standardCrouching;

            SuperIdling = superIdling;
            SuperJumping = superJumping;
            SuperRunning = superRunning;
            SuperFalling = superFalling;
            SuperCrouching = superCrouching;

            FireIdling = fireIdling;
            FireJumping = fireJumping;
            FireRunning = fireRunning;
            FireFalling = fireFalling;
            FireCrouching = fireCrouching;
        }
        

        public Texture2D GetSprite(IActionState actionState, IMarioPowerupStates powerUpState, GameTime gameTime)
        {
            if (powerUpState is MarioDeadState)
            {
                //dead :(
                return Dead;
            }
            else if (powerUpState is MarioStandardState)
            {
                if(actionState is IdlingState)
                {
                    //standard idling
                    return StandardIdling;
                }
                else if(actionState is JumpingState)
                {
                    //standard jumping
                    return StandardJumping;
                }
                else if (actionState is FallingState)
                {
                    //standard falling
                    return StandardFalling;
                }
                else if (actionState is RunningState)
                {
                    //standard running
                    //animate
                    int animationIntervalTicks = 2000000;
                    long animationFrame = gameTime.TotalGameTime.Ticks / animationIntervalTicks;
                    int animationIndex = (int) (animationFrame % StandardRunning.Count);
                    return StandardRunning[animationIndex];
                }
                else if (actionState is CrouchingState)
                {
                    //standard crouching
                    return StandardCrouching;
                }

            }
            else if (powerUpState is MarioSuperState)
            {
                if (actionState is IdlingState)
                {
                    //super idling
                    return SuperIdling;
                }
                else if (actionState is JumpingState)
                {
                    //super jumping
                    return SuperJumping;
                }
                else if (actionState is FallingState)
                {
                    //super falling
                    return SuperFalling;
                }
                else if (actionState is RunningState)
                {
                    //super running
                    //animate
                    int animationIntervalTicks = 2000000;
                    long animationFrame = gameTime.TotalGameTime.Ticks / animationIntervalTicks;
                    int animationIndex = (int)(animationFrame % SuperRunning.Count);
                    return SuperRunning[animationIndex];
                }
                else if (actionState is CrouchingState)
                {
                    //super crouching
                    return SuperCrouching;
                }

            }
            else if (powerUpState is MarioFireState)
            {
                if (actionState is IdlingState)
                {
                    //fire idling
                    return FireIdling;
                }
                else if (actionState is JumpingState)
                {
                    //fire jumping
                    return FireJumping;
                }
                else if (actionState is FallingState)
                {
                    //fire falling
                    return FireFalling;
                }
                else if (actionState is RunningState)
                {
                    //animate
                    int animationIntervalTicks = 2000000;
                    long animationFrame = gameTime.TotalGameTime.Ticks / animationIntervalTicks;
                    int animationIndex = (int)(animationFrame % FireRunning.Count);
                    return FireRunning[animationIndex];
                }
                else if (actionState is CrouchingState)
                {
                    //fire crouching
                    return FireCrouching;
                }

            }
            return null;
        }
        
    }
}
