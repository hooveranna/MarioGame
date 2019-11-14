using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Sprites
{
    public interface ISprite
    {
        void Draw(SpriteBatch s);
        void Update(GameTime gameTime);
    }
}
