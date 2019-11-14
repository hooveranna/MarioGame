using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
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
using Sprint_4.Collision;
using System.IO;
using Sprint_4.Observer_Pattern;

namespace Sprint_4.Sprites
{
    public class MarioModel : ISprite, ICollidable
    {
        public bool leftFacing;
        public bool canMoveDown { get; set; }
        public bool support { get; set; }
        private bool hasDied = false;
        private bool warping = false;
        public bool gravityAllowed { get; set; }
        public int horizontalSpeed { get; set; }
        public int jumpSpeed { get; set; }
        public int heightJumped { get; set; }
        public int lives { get; set; }
        public int coins { get; set; }
        public int points { get; set; }
        public int time { get; set; }
        private GameTime lastUpdatedTime = new GameTime();
        private MarioEventArgs lastMarioArgsPassed;
        public Texture2D texture { get; set; }
        public Vector2 Position { get; set; }
        //States
        public IMarioPowerupStates CurrentPowerupState { get; set; }
        public IActionState actionState = IdlingState.Instance;
        //public IPowerupState powerupState;
        //private MarioSpriteBoxFactory spriteFactory;
        private MarioSpriteFactory MarioSpriteFactory { get; set; }
        //private IActionState prevState;
        public Vector2 Velocity;
        //public Vector2 Acceleration;
        public MarioSprite Sprite { get; set; }
        public double MarioHeightFactor { get; set; }
        public int DeadPositionFactor { get; set; }
        private Stopwatch invincibleFrames = new Stopwatch();
        public bool FeatureOn = false;
        public Vector2 Scale =new Vector2(1.5f,1.5f);
        public Color Color = Color.White;

        public delegate void ItemCollectedEventHandler(object source, ItemEventArgs args);
        public delegate void MarioGUIUpdatedEventHandler(object source, MarioEventArgs args);
        public delegate void MarioDeathEventHandler(object source, EventArgs args);
        public delegate void MarioJumpEventHandler(object source, EventArgs args);

        public event ItemCollectedEventHandler ItemCollected;
        public event MarioGUIUpdatedEventHandler MarioGUIUpdated;
        public event MarioDeathEventHandler MarioDeath;
        public event MarioJumpEventHandler MarioJump;

        public MarioModel(MarioSpriteFactory spriteFactory, Vector2 coordinates, Vector2 velocity)
        {
            //Mario states
            CurrentPowerupState = new MarioStandardState(this);
            CurrentPowerupState.Enter(null);

            leftFacing = false;
            canMoveDown = false;
            support = false;
            gravityAllowed = true;
            horizontalSpeed = 2;
            jumpSpeed = 3;
            heightJumped = 0;
            this.Position = coordinates;
            this.lives = 3;
            this.coins = 0;
            this.points = 0;
            this.time = 400;
            //this.powerupState = powerupState;
            //this.spriteFactory = spriteFactory;
            MarioSpriteFactory = spriteFactory;
            Sprite = new MarioSprite(this);
            Velocity = velocity;

            //DeadPositionFactor = powerupState.CollisionPositionFactor;
            //DeadPositionFactor = 1;
        }

        public void Draw(SpriteBatch s)
        {
            Sprite.Draw(s);
            
        }
        public void Update(GameTime gameTime)
        {
            if(this.time <= 0)
            {
                this.Kill();
            }
            CurrentPowerupState?.Update(gameTime);
            //DeadPositionFactor = powerupState.CollisionPositionFactor;
            if(DeadPositionFactor == 0)
            {
                Gravity(false);
            }
            Position += Velocity;

            //Debug.WriteLine("invincible frames: " + invincibleFrames.ElapsedMilliseconds);
            if (this.invincibleFrames.ElapsedMilliseconds >= 2000 /*|| !this.invincibleFrames.IsRunning*/)
            {
                Color = Color.White;
            }
        
            //position += new Vector2((int)(Velocity.X * gameTime.ElapsedGameTime.TotalSeconds), (int)(Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds));
            //handle illegal state where mario is standard and crouching -- can arise when mario takes damage while crouching
           /* if (powerupState is StandardState && actionState is CrouchingState)
            {
                this.actionState = IdlingState.Instance;
            }*/
            if (CurrentPowerupState is MarioStandardState && actionState is CrouchingState)
            {
                this.actionState = IdlingState.Instance;
            }

            //this.texture = spriteFactory.GetSprite(this.actionState, this.powerupState, gameTime);
            this.texture = MarioSpriteFactory.GetSprite(this.actionState, CurrentPowerupState, gameTime);
            UpdateMarioHeight();
          
            

            //Update and send Max Velocity
            //UpdateMaxVelocity(80f);
            //check for max height
            if (this.Velocity.Y == -jumpSpeed)
            {
                //Debug.WriteLine("the Update code is being run at all");
                UpdateJump(false);
            }
            //Debug.WriteLine("Mario has support");
            //support is updated when: mario moves left or right, mario stops jumping, mario collides horrizontally 
            if (IsMoving()==1)
            {
                Gravity(support);
            }
            else
            {
                this.actionState =  IdlingState.Instance;
            }
            //support = false;
            if(gameTime.TotalGameTime.TotalSeconds - lastUpdatedTime.TotalGameTime.TotalSeconds >= 1)
            {
                this.time--;
                lastUpdatedTime.TotalGameTime = gameTime.TotalGameTime;
            }
            
            MarioEventArgs newArgs = new MarioEventArgs() { Coins = this.coins, Lives = this.lives, Points = this.points, Time = this.time};
            if (!newArgs.Equals(lastMarioArgsPassed))
            {
                OnMarioGUIUpdated(newArgs);
            }
            lastMarioArgsPassed = newArgs;
            if (CurrentPowerupState is MarioDeadState)
            {
                if (!hasDied)
                {
                    hasDied = true;
                    lives--;
                }
                if (this.invincibleFrames.ElapsedMilliseconds >= 500)
                {
                    OnMarioDeath();
                }
            }
            if (warping)
            {
                this.Position = new Vector2(1660, 1136);
                warping = false;
            }
        }

        public void UpdateMarioHeight()
        {  
            //changes bounding box if mario is crouching, since the sprite size doesn't change
            //MarioHeightFactor = 1;
            if (actionState is CrouchingState)
            {
                MarioHeightFactor = 0.75;
            }
            else if (CurrentPowerupState is MarioStandardState || CurrentPowerupState is MarioDeadState)
            {
                MarioHeightFactor = 0.5;
            }
            else
            {
                MarioHeightFactor = 1;
            }

        }
        public void UpdateMaxVelocity(float maxVelocity)
        {
            //Set Maximum velocity
            int maxVel = (int)maxVelocity;
            if (Velocity.X >= maxVel)
            {
                Velocity.X = maxVel;
            }
            else if (Velocity.X <= -maxVel)
            {
                Velocity.X = -maxVel;
            }

            if (Velocity.Y >= maxVel)
            {
                Velocity.Y = maxVel;
            }
            else if (Velocity.Y <= -maxVel)
            {
                Velocity.Y = -maxVel;
            }
        }
        public Rectangle BoundingBox => (texture == null) ? new Rectangle() : new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)(texture.Width * Scale.X) *DeadPositionFactor, (int)((texture.Height * Scale.Y) * MarioHeightFactor)*DeadPositionFactor);

        public void UpdatePosition(int xpos, int ypos)
        {
            this.Position = new Vector2(xpos, ypos);
        }

        public void CollisionResponseTop(ICollidable collidable)
        {
            if(collidable is EnemyModel && !(collidable.State is GoombaInjuredState) && !(collidable.State is TurtleInjuredState))
            {
                this.TakeDamage();
            }else if(collidable is ItemModel)
            {
                this.CollideWithItem(collidable);
            }else if(collidable is BlockModel)
            {
                this.CollideVertical(false);
            }
            Gravity(support);
        }
        public void CollisionResponseBottom(ICollidable collidable)
        {
            if (collidable is EnemyModel)
            {
                this.Velocity.Y = 0;
                //enemy response will take care of becoming injured
            }
            else if (collidable is ItemModel)
            {
                this.CollideWithItem(collidable);
            }
            else if (collidable is BlockModel)
            {
                if (collidable.State is WarpPipeStandardState && this.Velocity.Y != 0)
                {
                    Debug.WriteLine("warp pipe is being activated right here");
                    this.Velocity = new Vector2(0, -2);
                    warping = true;
                }
                else
                {
                    this.CollideVertical(true);
                }
            }
            Gravity(support);
            support = false;
        }
        public void CollisionResponseSide(ICollidable collidable)
        {
            Debug.WriteLine("mario colliding from the side");
            if (collidable is EnemyModel && !(collidable.State is GoombaInjuredState) && !(collidable.State is TurtleInjuredState))
            {
                this.TakeDamage();
            }
            else if (collidable is ItemModel)
            {
                this.CollideWithItem(collidable);
            }
            else if (collidable is BlockModel)
            {
                //may take out this method, not sure yet
                this.CollideHorizontal(collidable);
            }
            Gravity(support);
        }
        //keeping this since the side doesn't matter
        public void CollideWithItem(ICollidable collidable)
        {
            Debug.WriteLine("mario is colliding with an item");
            OnItemCollected((ItemModel) collidable);
            if (collidable is FireFlowerModel)
            {
                CurrentPowerupState.FireTransition(null);
                this.points += 1000;
            }
            else
            if (collidable is RedMushroomModel)
            {
                if (CurrentPowerupState is MarioStandardState)
                {
                    CurrentPowerupState.SuperTransition(null);
                }
                this.points += 1000;
            }
            else
            if (collidable is GreenMushroomModel)
            {
                this.points += 1000;
                LifeOneUP();
            }
            else
            if (collidable is SuperStarModel)
            {
                this.points += 1000;
                //Mario gets invincibility for a bit
            }
            else
            if (collidable is CoinModel)
            {
                CollectCoin();
            }


        }
        public void CollideHorizontal(ICollidable collidable)
        {
            Debug.WriteLine("Horrizontal collision is occurring at " + this.Position + "and bottom is at " + (this.Position.Y + this.BoundingBox.Height));
            Debug.WriteLine("box's spot is " + collidable.BoundingBox);
            this.actionState = IdlingState.Instance;
            this.Velocity.X = 0;
            Gravity(support);
            support = false;
        }
        public void CollideVertical(bool standing)
        {
            //this.prevState = this.actionState;
            if (this.Velocity.Y != 0)
            {
                //Debug.WriteLine("there is Y velocity");
                //this.actionState = IdlingState.Instance;
                this.Velocity.Y = 0;
            }
            if (standing)
            {
                support = true;
                //Debug.WriteLine("colliding support is being checked");
            }
            //Gravity(support);
        }
        public void Warping()
        {

        }
        public IStates State => CurrentPowerupState;

        //moving methods (hopefully will move these to another class)
        public void MoveLeft()
        {
            if(leftFacing)
            {
                this.Velocity.X = -horizontalSpeed;
            }
            this.actionState = this.actionState.MoveLeft(ref leftFacing);
            support = false;
        }
        public void StopLeft()
        {
            if (this.Velocity.X == -horizontalSpeed)
            {
                this.Velocity.X = 0;
                if(this.Velocity.Y != -jumpSpeed)
                {
                    this.actionState = this.actionState.MoveRight(ref leftFacing);
                }
            }
        }
        public void MoveRight()
        {
            if (!leftFacing)
            {
                this.Velocity.X = horizontalSpeed;
            }
            this.actionState = this.actionState.MoveRight(ref leftFacing);
            support = false;
        }
        public void StopRight()
        {
            if(this.Velocity.X == horizontalSpeed)
            {
                this.Velocity.X = 0;
                if (this.Velocity.Y != -jumpSpeed)
                {
                    this.actionState = this.actionState.MoveLeft(ref leftFacing);
                }
            }
        }
        public void Jump()
        {
            if(!(this.actionState is CrouchingState))
            {
                this.Velocity.Y = -this.jumpSpeed;
            }
            this.actionState = this.actionState.Jump();
            OnJump();
        }
        public void UpdateJump( bool stoping)
        {
            int maxJumpHeight = 150;
            if(heightJumped > maxJumpHeight || stoping)
            {
                //Debug.WriteLine(this.heightJumped + " height jumped after stop");
                this.Velocity.Y = 0;
                heightJumped = 0;
                //this needs to change to falling once I get that implemented correctly
                if(this.actionState is JumpingState)
                {
                    this.actionState = this.actionState.Crouch(/*this.powerupState*/CurrentPowerupState);
                }
                support = false;
                Gravity(support);
            }
            else
            {
                this.heightJumped = this.heightJumped + jumpSpeed;
                //Debug.WriteLine( this.heightJumped + " heightJumped and " + maxJumpHeight + " maxJumpHeight.");
            }
        }
        public void Crouch()
        {
            if (canMoveDown)
            {
                if (this.Velocity.Y == jumpSpeed)
                {
                    this.Velocity.Y = 0;
                }
                else
                {
                    this.Velocity.Y = jumpSpeed;
                }
            }
            if (!(CurrentPowerupState is MarioStandardState))
            {
                Position = new Vector2(Position.X, Position.Y + 15);
            }
            this.actionState = this.actionState.Crouch(/*this.powerupState*/CurrentPowerupState);
            //this stop method is just the Jump method

        }
        public void StopCrouch()
        {
            /* if(!(this.powerupState is StandardState)){
                 this.actionState = this.actionState.Jump();
             }*/
            if (!(CurrentPowerupState is MarioStandardState))
            {
                this.actionState = this.actionState.Jump();
                Position = new Vector2(Position.X, Position.Y - 15);
            }

        }

        public int IsMoving()
        {
            int answer = 0;
            if (this.Velocity.Length() != 0)
            {
                answer = 1;
            }
            return answer;
        }

        public void ToggleCrouchCommand()
        {
            canMoveDown = !canMoveDown;
        }

        public void TakeDamage(bool invinc = true)
        {
            if (!invincibleFrames.IsRunning)
            {
                this.invincibleFrames.Start();
                CurrentPowerupState.DamageTransition(null);
            }
            Debug.WriteLine("invincible frames: " + invincibleFrames.ElapsedMilliseconds);
            if (!invinc || this.invincibleFrames.ElapsedMilliseconds >= 2000)
            {
                //this.powerupState = this.powerupState.TakeDamage();
                CurrentPowerupState.DamageTransition(null);
                this.invincibleFrames.Restart();
            }

            Color = Color.Red;
        }

        public void Standard()
        {
            //this.powerupState = StandardState.Instance;
            CurrentPowerupState.StandardTransition(null);
        }
        public void Super()
        {
            //this.powerupState = SuperState.Instance;
            CurrentPowerupState.SuperTransition(null);
        }
        public void Fire()
        {
            //this.powerupState = FireState.Instance;
            CurrentPowerupState.FireTransition(null);
        }

        public void Gravity(bool onSomething)
        {
            //this will do something 
            if (!onSomething && this.Velocity.Y != -jumpSpeed && gravityAllowed)
            {
                //this.actionState = this.actionState.Fall();
                this.Velocity.Y = jumpSpeed;
            }
            //support = false;
        }
        public void ToggleGravity()
        {
            gravityAllowed = !gravityAllowed;
        }
        public void CollectCoin()
        {
            this.coins++;
            this.points += 100;
            if(this.coins >= 100)
            {
                coins -= 100;
                LifeOneUP();
            }
        }

        public void Kill()
        {
            while (!(CurrentPowerupState is MarioDeadState))
            {
                TakeDamage(false);
            }
        }

        private void LifeOneUP()
        {
            this.lives++;
            /*SoundEffect sound = SoundFiles[4];
            sound.Play();
            */
        }

        protected virtual void OnItemCollected(ItemModel item)
        {
            if(ItemCollected != null)
            {
                ItemCollected(this, new ItemEventArgs() { Item = item });
            }
        }

        protected virtual void OnMarioGUIUpdated(MarioEventArgs args)
        {
            if(MarioGUIUpdated != null)
            {
                MarioGUIUpdated(this, args);
            }
        }

        protected virtual void OnMarioDeath()
        {
            if (MarioDeath != null)
            {
                MarioDeath(this, new EventArgs());
            }
        }

        protected virtual void OnJump()
        {
            if(MarioJump != null)
            {
                MarioJump(this, new EventArgs());
            }
        }
    }
}
