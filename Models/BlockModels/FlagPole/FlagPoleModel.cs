using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ParticleEngine2D;
using Sprint_4.Collision;
using Sprint_4.Commands;
using Sprint_4.Sprites;
using Sprint_4.States;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Models.BlockModels
{
    class FlagPoleModel : BlockModel
    {
        public delegate void WinEventHandler(object source, EventArgs args);

        public event WinEventHandler WinEvent;

        private Stopwatch winTime = new Stopwatch();

        bool HasCollided = false;
        Vector2 Coordinates;
        public FlagPoleModel(BlockSpriteFactory blockSpriteFactory, Vector2 coordinates, Vector2 velocity)
            : base(blockSpriteFactory)
        {
            //Initialize state first
            CurrentState = new FlagPoleStandardState(this);
            CurrentState.Enter(null);

            //Define the characteristics of a brick block here
            Position = coordinates;
            //If additional frames of QuestionBlocks are added, update Columns
            Columns = 5;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
            Velocity = velocity;
            Coordinates = coordinates;
            //Particles
            //Texture2D brickTexture = BlockSpriteFactory.GetBlockSprite(CurrentState, "brick");
            //List<Texture2D> textures = new List<Texture2D>();
            //textures.Add(brickTexture);
            //ParticleEngine = new ParticleEngine(textures, Position);

        }
        public override Rectangle BoundingBox
        {
            get
            {
                int width = this.Texture.Width;
                if (TotalFrames > 0)
                {
                    width = width / TotalFrames;
                }
                return new Rectangle((int)this.Position.X+28, (int)this.Position.Y + ExplodedPositionFactor, width + (int)Scale.X-10, this.Texture.Height + (int)Scale.Y);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(winTime.Elapsed.TotalSeconds >= 4)
            {
                OnWin();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);
            //ParticleEngine.Draw(spriteBatch);
        }

        public override void CollisionResponseTop(ICollidable collidable)
        {
            if (collidable is MarioModel && !HasCollided)
            {
                //If mario hits top of flag, give an extra life
                MarioModel marioModel = (MarioModel)collidable;
                marioModel.lives++;
                CurrentState.BumpTransition();
                HasCollided = true;
                //Call Finalize Points
                ICommand com = new GoToCastleCommand(marioModel);
                com.Execute();
                winTime.Start();
            }
        }

        
        public override void CollisionResponseSide(ICollidable collidable)
        {
            if (collidable is MarioModel && !HasCollided)
            {
                MarioModel marioModel = (MarioModel)collidable;
                RewardPointsByHeight(marioModel);
                CurrentState.BumpTransition();
                HasCollided = true;
                //Call Finalize Points
                ICommand com = new GoToCastleCommand(marioModel);
                com.Execute();
                winTime.Start();
            }
        }

    
        public void RewardPointsByHeight(MarioModel marioModel)
        {
            //Cooridnates start from top left of the flag
            float coorY = Coordinates.Y;
            float marioY = marioModel.Position.Y;
            //Based on where the Y position of Mario is relative to flag's coordinates, award different points
            if (marioY <= coorY + 25)
            {
                //Top side of Flag pole (128-153 Pixels high). NOT TOP TOP of flag pole though.
                //Give 4000 Points
                marioModel.points += 4000;
            }
            else if (marioY <= coorY + 70)
            {
                //2nd Top side of Flag pole (82-127 Pixels high)
                //Give 2000 Points
                marioModel.points += 2000;
            }
            else if (marioY <= coorY + 93)
            {
                //3rd Top side of Flag pole (58-81 Pixels high)
                //Give 800 Points
                marioModel.points += 800;
            }
            else if (marioY <= coorY + 132)
            {
                //2nd Bottom side of Flag pole (18-57 Pixels high)
                //Give 400 Points
                marioModel.points += 400;
            }
            else if (marioY <= coorY + 153)
            {
                //Bottom side of Flag pole (0-17 Pixels high)
                //Give 100 Points
                marioModel.points += 100;
            }

            //Finally multiply the points by time remaining
            //MarioModel needs access to read time.
            marioModel.points += marioModel.time * 50;
            marioModel.time = 400;
        }

        //private static int FinalizePoints(int time, int points)
        //{
        //   return points *= time;
        //}
        protected virtual void OnWin()
        {
            if(WinEvent != null)
            {
                WinEvent(this, new EventArgs());
            }
        }
    }
}
