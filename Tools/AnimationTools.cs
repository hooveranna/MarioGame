using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Tools
{
    static class AnimationTools
    {
        public static List<Texture2D> GetAnimationFramesFromTextureByColumn(GraphicsDevice graphicsDevice, Texture2D texture, int numFrames)
        {
            List<Texture2D> frames = new List<Texture2D>();
            //adapted from Stack Overflow
            for (int i = 0; i < numFrames; i++)
            {
                Rectangle sourceRectangle = new Rectangle(i * (texture.Width / numFrames), 0, texture.Width / numFrames, texture.Height);

                Texture2D cropTexture = new Texture2D(graphicsDevice, sourceRectangle.Width, sourceRectangle.Height);
                Color[] data = new Color[sourceRectangle.Width * sourceRectangle.Height];
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                cropTexture.SetData(data);
                frames.Add(cropTexture);
            }
            return frames;
        }

        public static List<Texture2D> GetAnimationFramesFromTextureByRow(GraphicsDevice graphicsDevice, Texture2D texture, int numFrames)
        {
            List<Texture2D> frames = new List<Texture2D>();
            //adapted from Stack Overflow
            for (int i = 0; i < numFrames; i++)
            {
                Rectangle sourceRectangle = new Rectangle(0, i * (texture.Height / numFrames), texture.Width, texture.Height / numFrames);

                Texture2D cropTexture = new Texture2D(graphicsDevice, sourceRectangle.Width, sourceRectangle.Height);
                Color[] data = new Color[sourceRectangle.Width * sourceRectangle.Height];
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                cropTexture.SetData(data);
                frames.Add(cropTexture);
            }
            return frames;
        }
    }
}
