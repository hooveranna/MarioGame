using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Sprites;
using Sprint_4.Sprites.BlockSprites;
using Sprint_4.States;
using Sprint_4.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParticleEngine2D;
using System.Diagnostics;
using Sprint_4.Observer_Pattern;

namespace Sprint_4.Models
{
    public abstract class BlockModel : ISprite, ICollidable, ICameraObserver
    {
        public delegate void BumpEventHandler(object source, BlockEventArgs args);

        public event BumpEventHandler BumpEvent;
        //Position, rotation, and effects
        private int hasStartedMoving = 0;
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }
        public float LayerDepth { get; set; }
        public int ExplodedPositionFactor { get; set; }

        public Vector2 Velocity { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public SpriteEffects SpriteEffects { get; set; }

        // Texture and Animations
        public Texture2D Texture { get; set; }
        public bool IsAnimated { get; set; }
        public int CurrentFrame { get; set; }
        public int TotalFrames { get; set; }
        public int MillisecondsPerFrame { get; set; }
        public Color Color { get; set; }
        public Stopwatch Time { get; set; }


        public ParticleEngine ParticleEngine { get; set; }
        //States
        public IBlockStates CurrentState { get; set; }

        //Sprites
        public ISprite Sprite { get; set; }
        public BlockSpriteFactory BlockSpriteFactory { get; set; }

        protected BlockModel(BlockSpriteFactory blockSpriteFactory)
        {
            BlockSpriteFactory = blockSpriteFactory;
            Sprite = new BlockSprite(this);
            Color = Color.White;
            Time = new System.Diagnostics.Stopwatch();
        }

        public virtual void Draw(SpriteBatch s)
        {
            Sprite.Draw(s);
        }
        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            CurrentState?.Update(gameTime);
            if (Time.IsRunning && Time.ElapsedMilliseconds >= 1)
            {
                ExplodedPositionFactor = 3000;
            }
        }

        public virtual Rectangle BoundingBox
        {
            get
            {
                int width = this.Texture.Width;
                if (TotalFrames > 0)
                {
                    width = width / TotalFrames;
                }
                return new Rectangle((int)this.Position.X, (int)this.Position.Y + ExplodedPositionFactor, width + (int)Scale.X, this.Texture.Height + (int)Scale.Y);
            }
        }

        public void UpdatePosition(int xpos, int ypos)
        {
            this.Position = new Vector2(xpos, ypos);
        }

        public virtual void CollisionResponseTop(ICollidable collidable)
        {
            
        }
        //this is the only one that needs to do something for almost all blocks
        public virtual void CollisionResponseBottom(ICollidable collidable)
        {
            OnBump(new BlockEventArgs() { Model = this });
        }
        public virtual void CollisionResponseSide(ICollidable collidable)
        {
            
        }
        public IStates State => CurrentState;

        public int HasStartedMoving { get => hasStartedMoving; set => hasStartedMoving = value; }

        public int IsMoving()
        {
            int answer = 0;
            if(this.Velocity.Length() != 0)
            {
                answer = 1;
            }
            return answer;
        }
        public void Gravity(bool onSomething)
        {
            throw new NotImplementedException();
        }

        public void GetNotified(Rectangle r)
        {
            if (r.Intersects(BoundingBox))
            {
                //Console.WriteLine("width is: " + r.Width);
                //Console.WriteLine("height is: " + r.Height);
                //Console.WriteLine("X is: " + r.X);
                //Console.WriteLine("Y is: " + r.Y);
                HasStartedMoving++;
            }
        }

        public void OnBump(BlockEventArgs args)
        {
            if(BumpEvent != null)
            {
                BumpEvent(this, args);
            }
        }
    }
}
