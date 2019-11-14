using Microsoft.Xna.Framework;
using Sprint_4.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Collision
{
    public class InvisibleWall : ICollidable
    {
        public Vector2 Position { get; set; }
        //private bool vertical;
        private int length;
        private Rectangle boundingBox;
        public InvisibleWall(Vector2 position, bool vertical, int length)
        {
            this.Position = position;
            //this.vertical = vertical;
            this.length = length;
            int width;
            int height;
            if (vertical)
            {
                width = 20;
                height = this.length;
            }
            else
            {
                height = 20;
                width = this.length;
            }
            this.boundingBox = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public IStates State => null;

        Rectangle ICollidable.BoundingBox => this.boundingBox;
        public void UpdatePosition(int xpos, int ypos)
        {
            this.Position = new Vector2(xpos, ypos);
        }
        public void CollisionResponseTop(ICollidable collidable)
        {

        }
        public void CollisionResponseBottom(ICollidable collidable)
        {

        }
        public void CollisionResponseSide(ICollidable collidable)
        {

        }

        public void Gravity(bool onSomething)
        {
            throw new NotImplementedException();
        }

        public int IsMoving()
        {
            return 0;
        }
    }
}
