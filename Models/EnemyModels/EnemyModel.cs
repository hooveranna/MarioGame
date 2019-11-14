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
using Sprint_4.Observer_Pattern;
using System.Diagnostics;

namespace Sprint_4.Models
{
    public abstract class EnemyModel : ISprite, ICollidable, ICameraObserver
    {
        //Position, rotation, and effects
        public bool LeftFacing { get; set; }
        public bool MovingLeft { get; set; }
        public bool Support { get; set; }
        public bool GravityAllowed { get; set; }
        private int HasStartedMoving = 0;
        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }
        public float LayerDepth { get; set; }
        public int InjuredVariable { get; set; }
        public Vector2 Velocity { get; set; }
        public float InjuredHeightFactor { get; set; }
        public int InjuredPositionFactor { get; set; }
        //public Vector2 Acceleration { get; set; }

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
        public int SpriteCount { get; set; }
        public Color Color { get; set; }
        public Stopwatch Time { get; set; }
        //States
        public IEnemyStates CurrentState { get; set; }
        

        //Sprites
        public ISprite Sprite { get; set; }
        public ItemEnemySpriteFactory ItemEnemySpriteFactory { get; set; }
        public int HorizontalV { get; set; }
        public int VerticalV { get; set; }

        protected EnemyModel(ItemEnemySpriteFactory itemEnemySpriteFactory)
        {
            ItemEnemySpriteFactory = itemEnemySpriteFactory;
            Sprite = new EnemySprite(this);
            Support = false;
            HorizontalV = 1;
            VerticalV = 2;
        }

        public virtual void Draw(SpriteBatch s)
        {
            Sprite.Draw(s);
        }
        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            //Velocity += Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Velocity;
            //Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            CurrentState?.Update(gameTime);
            if (IsMoving()==1)
            {
                Gravity(Support);
            }
            //Enemy Movement
            if (HasStartedMoving == 1)
            {
                //Only move left ONCE.
                MovingLeft = true;
                MoveLeft();
                HasStartedMoving++;
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                int width = this.Texture.Width;
                if (TotalFrames > 0)
                {
                    width = width / (TotalFrames + InjuredVariable);
                }
                return new Rectangle((int)this.Position.X, (int)(this.Position.Y) + InjuredPositionFactor, (width + (int)Scale.X) , (int)((this.Texture.Height * InjuredHeightFactor + (Scale.Y)) ));

            }
        }
        public void UpdatePosition(int xpos, int ypos)
        {
            this.Position = new Vector2(xpos, ypos);
        }
        public virtual void CollisionResponseTop(ICollidable collidable)
        {
            if (collidable is MarioModel)
            {
                if (!(this.CurrentState is TurtleInjuredState))
                {
                    ((MarioModel)collidable).points += 100;
                }
                this.CurrentState.InjuredTransition();
            }
        }
        public void CollisionResponseBottom(ICollidable collidable)
        {
            if(collidable is BlockModel)
            {
                Support = true;
                this.Velocity = new Vector2(this.Velocity.X, 0);
            }
        }
        public virtual void CollisionResponseSide(ICollidable collidable)
        {
            //Velocity = new Vector2(0 - this.Velocity.X, Velocity.Y);
            //Debug.WriteLine("horizontal collision is being run enemy");

            //LeftFacing = true;
            //Velocity = new Vector2(-Velocity.X, Velocity.Y);
            if (MovingLeft)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
            Support = false;
        }
        public IStates State => CurrentState;

        public int IsMoving()
        {
            int answer = 0;
            if (this.Velocity.Length() != 0)
            {
                answer = 1;
            }
            return answer;
        }
        public void Gravity(bool onSomething)
        {
            //this will do something 
            if (!onSomething)
            {
                Velocity = new Vector2(this.Velocity.X, VerticalV);
            }
            Support = false;
        }

        //Enemy Movement
        public virtual void MoveLeft()
        {
            Velocity = new Vector2(-HorizontalV, Velocity.Y);
            // Velocity = new Vector2(-this.Velocity.X, Velocity.Y);

            MovingLeft = true;
            LeftFacing = true;
            //LeftFacing = !LeftFacing;
            Support = false;
        }
        public virtual void MoveRight()
        {
            Velocity = new Vector2(HorizontalV, Velocity.Y);
            // Velocity = new Vector2(-this.Velocity.X, Velocity.Y);

            MovingLeft = false;
            LeftFacing = false;
            //LeftFacing = !LeftFacing;
            Support = false;
        }
        public virtual void Fall()
        {
            this.Gravity(false);
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
    }
}
