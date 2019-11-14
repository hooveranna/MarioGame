using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Factories;
using Sprint_4.States;
using Sprint_4.States.Action_States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_4.Models.BlockModels;
using Sprint_4.Models;
using System.Diagnostics;

namespace Sprint_4.Sprites
{
    public class MarioSprite : ISprite
    {
        //Only controls the drawing and animation of Mario
        //private Vector2 position;
        public MarioModel Mario;
        //MarioSpriteBoxFactory SpriteFactory;
        public MarioSprite(MarioModel mario)
        {
            //this.position = coordinates;
            Mario = mario;
            //SpriteFactory = spriteFactory;
        }

        public void Draw(SpriteBatch s)
        {
#pragma warning disable 618
            //disabling because these are the best methods for drawing mario
            //For testing collision, Mario.Position should be used.
            //Debug.WriteLine("Mario's position is " + (Mario.Position));
            //Vector2 location = new Vector2((int)Mario.position.X, (int)Mario.position.Y);
            if (Mario.leftFacing)
            {
                if (Mario.texture != null)
                { 
                    s.Draw(Mario.texture, Mario.Position, color: Mario.Color, effects: SpriteEffects.FlipHorizontally, scale: Mario.Scale);
                }
            }
            else
            {
                if (Mario.texture != null)
                {
                    s.Draw(Mario.texture, Mario.Position, color: Mario.Color, scale: Mario.Scale);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
        }

    }
}
