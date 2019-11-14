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
using System.Diagnostics;

namespace Sprint_4.Models
{
    public abstract class ItemModel : ISprite, ICollidable
    {
        //Position, rotation, and effects
        public bool Support { get; set; }
        public bool CanGravity { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }
        public float LayerDepth { get; set; }
        public bool IsVisible { get; set; }
        public Vector2 Velocity { get; set; }
        public int ConsumedPositionFactor { get; set; }
        //public Vector2 Acceleration { get; set; }
        public int verticalV { get; set; }
        public int horizontalV { get; set; }
        public Vector2 MoveAwayFactor { get; set; }

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
        public IItemStates CurrentState { get; set; }

        //Sprites
        public ISprite Sprite { get; set; }
        public ItemEnemySpriteFactory ItemEnemySpriteFactory { get; set; }

        protected ItemModel(ItemEnemySpriteFactory itemEnemySpriteFactory)
        {
            ItemEnemySpriteFactory = itemEnemySpriteFactory;
            Sprite = new ItemSprite(this);
            IsVisible = true;
            ConsumedPositionFactor = 1;
            Support = false;
            CanGravity = false;
            verticalV = 1;
            horizontalV = 0;
            MoveAwayFactor = new Vector2(horizontalV, verticalV);

            Time = new Stopwatch();
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
            if (CanGravity)
            {
                Gravity(Support);
                Support = false;
            }
            if (Time.IsRunning && Time.ElapsedMilliseconds >= 1)
            {
                ConsumedPositionFactor = 3000;
            }
        }
        public Rectangle BoundingBox
        {
            get
            {
                int width = this.Texture.Width;
                if (TotalFrames > 0)
                {
                    width = width / TotalFrames;
                }
                return new Rectangle((int)this.Position.X, (int)this.Position.Y*ConsumedPositionFactor, (width + (int)Scale.X)/**ConsumedPositionFactor*/, (this.Texture.Height + (int)Scale.Y)/**ConsumedPositionFactor*/);
            }
        }

        public void UpdatePosition(int xpos, int ypos)
        {
            this.Position = new Vector2(xpos, ypos);
        }
        //collision on top of Item
        public void CollisionResponseTop(ICollidable collidable)
        {
            if (collidable is MarioModel)
            {
                CurrentState.ConsumedTransition();
            }
            else if (collidable is BlockModel)
            {
                this.CollideVertical(false);
            }
        }
        //collision on bottom of Item
        public void CollisionResponseBottom(ICollidable collidable)
        {
            if (collidable is MarioModel)
            {
                CurrentState.ConsumedTransition();
            }
            else if (collidable is BlockModel)
            {
                this.CollideVertical(true);
            }
        }
        public void CollisionResponseSide(ICollidable collidable)
        {
            if (collidable is MarioModel)
            {
                CurrentState.ConsumedTransition();
                //Debug.WriteLine("colliding with mario on item's side");
            }
            if (collidable is BlockModel)
            {
                Velocity = new Vector2(0 - this.Velocity.X, this.Velocity.Y);
                //Debug.WriteLine("Inside itemmodel's side collision's if statement");
            }

            //Debug.WriteLine("Inside itemmodel's side but outside collision's if statement");
            Support = false;
        }
        public virtual void CollideVertical(bool standing)
        {
            if (standing && CanGravity)
            {
                Support = true;
                Velocity = new Vector2(this.Velocity.X, 0);
            }
            else if (CanGravity)
            {
                Velocity = new Vector2(this.Velocity.X, verticalV);
            }
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
        public virtual void Gravity(bool onSomething)
        {
            if (!onSomething)
            {
               Velocity = new Vector2(this.Velocity.X, verticalV);
            }

        }
        public virtual void Move(Vector2 blockPosition,bool marioLeftFacing)
        {
            //Each Item implements move differently
        }
    }
}
