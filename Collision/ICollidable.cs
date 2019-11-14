using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.States;

namespace Sprint_4
{
    public interface ICollidable
    {
        Rectangle BoundingBox { get; }
        Vector2 Position { get; set; }
        //void CollisionResponse(ICollidable collidable);
        void CollisionResponseTop(ICollidable collidable);
        void CollisionResponseBottom(ICollidable collidable);
        void CollisionResponseSide(ICollidable collidable);
        //void CollisionResponseRight(ICollidable collidable);
        IStates State { get; }
        void UpdatePosition(int xpos, int ypos);
        int IsMoving();
        void Gravity(bool onSomething);
    }
}
