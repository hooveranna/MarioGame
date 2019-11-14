using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Sprites;
using Sprint_4.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Models
{
    class GoombaEnemyModel : EnemyModel
    {
        public GoombaEnemyModel(ItemEnemySpriteFactory itemEnemySpriteFactory, Vector2 coordinates, Vector2 velocity)
            : base(itemEnemySpriteFactory)
        {
            Time = new System.Diagnostics.Stopwatch();
            Texture = ItemEnemySpriteFactory.GetEnemySprite("goomba");
            //Initialize state first
            CurrentState = new GoombaStandardState(this);
            CurrentState.Enter(null);

            //Define the characteristics of a brick block here
            Position = coordinates;
            CurrentFrame = 0;
            //If additional frames of QuestionBlocks are added, update Columns
            Columns = 3;
            Rows = 1;
            LayerDepth = 1;
            Scale = new Vector2(10, 10);
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows ;
            Velocity = velocity;

        }

        public override void Update(GameTime gameTime)
        {
            if (Time.IsRunning && Time.ElapsedMilliseconds >= 1000)
            {
                IsVisible = false;
                //InjuredPositionFactor = 3000;
            }
            else if (Time.IsRunning && Time.ElapsedMilliseconds >= 1)
            {
                InjuredPositionFactor = 3000;
            }
            base.Update(gameTime);
        }
    }
}
