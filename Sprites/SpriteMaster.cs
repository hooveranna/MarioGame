using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprint_4.Sprites
{
    class SpriteMaster
    {
        private SpriteBatch parallaxedBatch;
        private SpriteBatch unparallaxedBatch;
        private HashSet<ISprite> parallaxedSprites;
        private HashSet<ISprite> unparallaxedSprites;
        private Camera camera;
        public SpriteMaster(SpriteBatch parallaxed, SpriteBatch unparallaxed)
        {
            this.parallaxedBatch = parallaxed;
            this.unparallaxedBatch = unparallaxed;
            this.unparallaxedSprites = new HashSet<ISprite>();
            this.parallaxedSprites = new HashSet<ISprite>();
        }

        public void Add(ISprite sprite, bool parallax = false)
        {
            if (parallax)
            {
                parallaxedSprites.Add(sprite);
            }
            else
            {
                unparallaxedSprites.Add(sprite);
            }
        }

        public void Begin()
        {
            Vector2 parallax = new Vector2(0.5f);
            if (this.camera != null)
            {
                parallaxedBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null, null, camera.GetViewMatrix(parallax));
                unparallaxedBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(Vector2.One));
            }
            else
            {
                parallaxedBatch.Begin();
                unparallaxedBatch.Begin();
            }
        }

        public void Draw()
        {
            //Debug.WriteLine("SpriteMaster.Draw is being run");
            foreach (ISprite sprite in this.parallaxedSprites)
            {
                sprite.Draw(parallaxedBatch);
            }
            foreach (ISprite sprite in this.unparallaxedSprites)
            {
                sprite.Draw(unparallaxedBatch);
            }
        }

        public void End()
        {
            parallaxedBatch.End();
            unparallaxedBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            camera?.LookAtMario();
            foreach (ISprite sprite in this.parallaxedSprites)
            {
                sprite.Update(gameTime);
            }
            foreach (ISprite sprite in this.unparallaxedSprites)
            {
                sprite.Update(gameTime);
            }
            //camera?.LookAtMario();

            //camera?.Notify();
        }

        public void SetCamera(Camera cameraInput)
        {
            this.camera = cameraInput;
        }

        internal void Dispose()
        {
            parallaxedBatch.Dispose();
            unparallaxedBatch.Dispose();

        }
    }
}
