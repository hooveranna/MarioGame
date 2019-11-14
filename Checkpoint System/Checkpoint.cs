using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint_4.Observer_Pattern;
using Sprint_4.Sprites;
using Sprint_4.States;

namespace Sprint_4.Checkpoint_System
{
    class Checkpoint : ICollidable
    {
        public delegate void CheckpointEventHandler(object source, CheckpointEventArgs args);

        public event CheckpointEventHandler CheckpointReached;
        Rectangle boundingBox;
        public Checkpoint(int x, int y, int levelHeight)
        {
            this.Position = new Vector2(x, y);
            this.boundingBox = new Rectangle(x, 0, 1, levelHeight);
        }
        public Rectangle BoundingBox => boundingBox;

        public Vector2 Position { get; set ; }

        public IStates State => null;

        public void CollisionResponseBottom(ICollidable collidable)
        {
            Console.WriteLine("COLLISION ON BOTTOM OF CHECKPOINT");
            if (collidable is MarioModel)
            {
                OnCheckpointReached();
            }
        }

        public void CollisionResponseSide(ICollidable collidable)
        {
            Console.WriteLine("COLLISION ON side OF CHECKPOINT");
            if (collidable is MarioModel)
            {
                OnCheckpointReached();
            }
        }

        public void CollisionResponseTop(ICollidable collidable)
        {
            Console.WriteLine("COLLISION ON top OF CHECKPOINT");
            if (collidable is MarioModel)
            {
                OnCheckpointReached();
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

        protected virtual void OnCheckpointReached()
        {
            if (CheckpointReached != null)
            {
                CheckpointReached(this, new CheckpointEventArgs() { Coordinates = this.Position });
            }
        }
    }
}
