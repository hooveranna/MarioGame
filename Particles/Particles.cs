using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ParticleTest.Classes
{
    //Adapted from rbwhitaker's wikidot tutorials
    public class Particles
    {
        public Vector2 Velocity { get; set; }
        public float Angle { get; set; }            // The current angle of rotation of the particle
        public float AngularVelocity { get; set; }    // The speed that the angle is changing
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }        
        public Vector2 Position { get; set; }        // The current position of the particle                         
        public float Size { get; set; }               
        public int LifeTime { get; set; }                // The 'life time' of the particle

        public Particles(Texture2D texture, Vector2 position, Vector2 velocity,
            float angle, float angularVelocity, Color color, float size, int lifeTime)
        {
            AngularVelocity = angularVelocity;
            Color = color;
            Size = size;
            LifeTime = lifeTime;
            Texture = texture;
            Position = position;
            Velocity = velocity;
            Angle = angle;
        }

        public void Update()
        {
            LifeTime--;
            Position += Velocity;
            Angle += AngularVelocity;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Vector2 startingPoint = new Vector2(Texture.Width / 2, Texture.Height / 2);

            spriteBatch.Draw(Texture, Position, sourceRectangle, Color,
                Angle, startingPoint, Size, SpriteEffects.None, 0f);
        }
    }
}
