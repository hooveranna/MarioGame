using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint_4.Sprites;
using Sprint_4.States;

namespace Sprint_4.Collision
{
    public class KillBox : ICollidable
    {
        private Rectangle box;

        public KillBox(int y, int width)
        {
            box = new Rectangle(0, y, width, 1);
        }
        public Rectangle BoundingBox => box;

        public Vector2 Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

        public IStates State => null;

        public void CollisionResponseBottom(ICollidable collidable)
        {
            if(collidable is MarioModel)
            {
                ((MarioModel)collidable).Kill();
            }
        }

        public void CollisionResponseSide(ICollidable collidable)
        {
            if (collidable is MarioModel)
            {
                ((MarioModel)collidable).Kill();
            }
        }

        public void CollisionResponseTop(ICollidable collidable)
        {
            if (collidable is MarioModel)
            {
                ((MarioModel)collidable).Kill();
            }
        }

        public void Gravity(bool onSomething)
        {
            throw new NotImplementedException();
        }

        public int IsMoving()
        {
            return 2;
        }

        public void UpdatePosition(int xpos, int ypos)
        {
            throw new NotImplementedException();
        }
    }
}
