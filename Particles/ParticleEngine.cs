using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ParticleTest.Classes;

namespace ParticleEngine2D
{
    //Adapted from rbwhitaker's wikidot tutorials
    public class ParticleEngine
    {
        private List<Particles> particles;
        private List<Texture2D> textures;
        private Random random;
        public Vector2 EmitterLocation { get; set; }
        

        public ParticleEngine(List<Texture2D> textures, Vector2 location)
        {
            //The properties of the particles that affect Where the Paritcles generate
            EmitterLocation = location;
            this.textures = textures;
            particles = new List<Particles>();
            random = new Random();
        }

        public void Update(float scale)
        {
            //Change the total to reduce the number of particles generated
            int total = 1;

            for (int i = 0; i < total; i++)
            {
                particles.Add(GenerateNewParticle(scale));
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].LifeTime <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        private Particles GenerateNewParticle(float scale)
        {
            //Setting the position from the emitter and velocity randomly.
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(
                                    1f * (float)(random.NextDouble() * 2 - 1),
                                    1f * (float)(random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = new Color(
                        (float)random.NextDouble(),
                        (float)random.NextDouble(),
                        (float)random.NextDouble());
            int ttl = 5 + random.Next(40);
            //Use the scale given by the original texture to scale the particles.
            return new Particles(texture, position, velocity, angle, angularVelocity, color, scale, ttl);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
        }
    }
}