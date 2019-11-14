using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.States;
using Sprint_4.Sprites;

namespace Sprint_4.Collision
{
    class GridSquare
    {
        private List<ICollidable> moving;
        private List<ICollidable> nonMoving;
        private List<ICollidable> intangible;

        public GridSquare()
        {
            moving = new List<ICollidable>();
            nonMoving = new List<ICollidable>();
            intangible = new List<ICollidable>();
        }
        public void AddCollidable(ICollidable collidable)
        {
            if (collidable.IsMoving() == 1 && !(collidable.BoundingBox.Height == 0))
            {
                moving.Add(collidable);
            }
            else if(collidable.IsMoving() == 2)
            {
                intangible.Add(collidable);
            }
            else
            {
                nonMoving.Add(collidable);
            }
        }

        public void HandleCollisions()
        {
            //only check moving objects for collisions
            while (moving.Count > 0)
            {
                //check against all moving
                for (int j = 1; j < moving.Count; j++)
                {
                    if (moving[0].BoundingBox.Intersects(moving[j].BoundingBox))
                    {
                        CallCollisions(j, moving);
                        ClippingCorrection(j, moving);
                        //moving[0].CollisionResponse(moving[j]);
                        //moving[j].CollisionResponse(moving[0]);
                        //Debug.WriteLine("2 moving objects collided");
                    }
                }

                //check against non-moving
                for (int j = 0; j < nonMoving.Count; j++)
                {
                    if (moving[0].BoundingBox.Intersects(nonMoving[j].BoundingBox))
                    {
                        //Debug.WriteLine("before correction");
                        CallCollisions(j, nonMoving);
                        ClippingCorrection(j, nonMoving);
                        //Debug.WriteLine("after correction");
                        if (nonMoving[j].State is BrickBlockStandardState) {
                            //Debug.WriteLine("box y value is : " +  nonMoving[j].Position.Y);
                        }
                        //moving[0].CollisionResponse(nonMoving[j]);
                        //nonMoving[j].CollisionResponse(moving[0]);
                        //Debug.WriteLine("1 moving object collided with nonmoving");
                    }
                }
                if (moving[0] is MarioModel)
                {
                    for (int j = 0; j < intangible.Count; j++)
                    {
                        if (moving[0].BoundingBox.Intersects(intangible[j].BoundingBox))
                        {
                            intangible[j].CollisionResponseSide(moving[0]);
                        }
                    }
                }
                //remove from set of moving we care about
                moving.RemoveAt(0);
            }

        }

        public void CallCollisions(int j, List<ICollidable> other)
        {
            //top of mario
            //if (moving[0].BoundingBox.X <= (other[j].BoundingBox.X + other[j].BoundingBox.Width) && (moving[0].BoundingBox.X + moving[0].BoundingBox.Width) >= (other[j].BoundingBox.X + other[j].BoundingBox.Width) && moving[0].BoundingBox.Y <= (other[j].BoundingBox.Y + other[j].BoundingBox.Height) && other[j].BoundingBox.Y <= moving[0].BoundingBox.Y)
            //{
            //    //moving[0].CollisionResponseTop(other[j]);
            //    //other[j].CollisionResponseBottom(moving[0]); // The problem was here: it said "other[j].CollisionResponseBottom(other[j]);" which mean you are sending the same argument twice.
            //}
            //else if ((moving[0].BoundingBox.X + moving[0].BoundingBox.Width) >= other[j].BoundingBox.X && moving[0].BoundingBox.Y <= (other[j].BoundingBox.Y + other[j].BoundingBox.Height) && other[j].BoundingBox.Y <= moving[0].BoundingBox.Y)
            //{
            //    //moving[0].CollisionResponseTop(other[j]);
            //    //other[j].CollisionResponseBottom(moving[0]);
            //}
            ////bottom of mario
            //else if (moving[0].BoundingBox.X <= (other[j].BoundingBox.X + other[j].BoundingBox.Width) && (moving[0].BoundingBox.Y + moving[0].BoundingBox.Height) >= other[j].BoundingBox.Y)
            //{
            //    //moving[0].CollisionResponseBottom(other[j]);
            //    //other[j].CollisionResponseTop(moving[0]);
            //}
            //else if ((moving[0].BoundingBox.X + moving[0].BoundingBox.Width) >= other[j].BoundingBox.X && (moving[0].BoundingBox.Y + moving[0].BoundingBox.Height) >= other[j].BoundingBox.Y)
            //{
            //    //moving[0].CollisionResponseBottom(other[j]);
            //    //other[j].CollisionResponseTop(moving[0]);
            //}
            ////ClippingCorrection(j, other);
            ////Horizontal Collisions
            //if (other[j].BoundingBox.X <= (moving[0].BoundingBox.X + moving[0].BoundingBox.Width) && (other[j].BoundingBox.Y + other[j].BoundingBox.Height) <= moving[0].BoundingBox.Y)
            //{
            //    //moving[0].CollisionResponseSide(other[j]);
            //    //other[j].CollisionResponseSide(moving[0]);
            //    Debug.WriteLine("1 horizontal collision");
            //}
            //else if ((other[j].BoundingBox.X + other[j].BoundingBox.Width) >= moving[0].BoundingBox.X && (other[j].BoundingBox.Y + other[j].BoundingBox.Height) <= moving[0].BoundingBox.Y)
            //{
            //    //moving[0].CollisionResponseSide(other[j]);
            //    //other[j].CollisionResponseSide(moving[0]);
            //    Debug.WriteLine("2 horizontal collision");
            //}
            //else if (other[j].BoundingBox.X <= (moving[0].BoundingBox.X + moving[0].BoundingBox.Width) && other[j].BoundingBox.Y >= (moving[0].BoundingBox.Y + moving[0].BoundingBox.Height))
            //{
            //    //moving[0].CollisionResponseSide(other[j]);
            //    //other[j].CollisionResponseSide(moving[0]);
            //    Debug.WriteLine("3 horizontal collision");
            //}
            //else if ((other[j].BoundingBox.X + other[j].BoundingBox.Width) >= moving[0].BoundingBox.X && other[j].BoundingBox.Y >= (moving[0].BoundingBox.Y + moving[0].BoundingBox.Height))
            //{
            //    //moving[0].CollisionResponseSide(other[j]);
            //    //other[j].CollisionResponseSide(moving[0]);
            //    Debug.WriteLine("4 horizontal collision");
            //}
            //Tried adding stuff from sprint 3's blockmodel, but that didnt help at all
            /*
            if ((other[j].BoundingBox.X + other[j].BoundingBox.Width) >= moving[0].BoundingBox.X && other[j].BoundingBox.Y >= (moving[0].BoundingBox.Y + moving[0].BoundingBox.Height))
            {
                if ((other[j].BoundingBox.X + other[j].BoundingBox.Width) - moving[0].BoundingBox.X > (moving[0].BoundingBox.Y + moving[0].BoundingBox.Height) - other[j].BoundingBox.Y)
                {
                    moving[0].CollisionResponseSide(other[j]);
                    other[j].CollisionResponseSide(moving[0]);
                }
            }
            else if (other[j].BoundingBox.X <= (moving[0].BoundingBox.X + moving[0].BoundingBox.Width) && other[j].BoundingBox.Y >= (moving[0].BoundingBox.Y + moving[0].BoundingBox.Height))
            {
                if ((other[j].BoundingBox.X + other[j].BoundingBox.Width) - moving[0].BoundingBox.X > (moving[0].BoundingBox.Y + moving[0].BoundingBox.Height) - other[j].BoundingBox.Y)
                {
                    moving[0].CollisionResponseSide(other[j]);
                    other[j].CollisionResponseSide(moving[0]);
                }
            }*/
            //conditions are right for a vertical collision
            Rectangle overlap = Rectangle.Intersect(moving[0].BoundingBox, other[j].BoundingBox);
            Debug.WriteLine(overlap.Width + " " + overlap.Height);
            //top/bottom intersect
            if (overlap.Height > 0 && overlap.Width > 0 && overlap.Height < 4)
            {
                int difTop = overlap.Y - moving[0].BoundingBox.Y;
                int difbottom = (moving[0].BoundingBox.Y + moving[0].BoundingBox.Height) - overlap.Y;
                if (difTop > difbottom)
                {
                    //colliding with the bottom of moving
                    //Debug.WriteLine("bottom collision");
                    moving[0].CollisionResponseBottom(other[j]);
                    other[j].CollisionResponseTop(moving[0]);
                }
                else
                {
                    //colliding with the top of moving
                    //Debug.WriteLine("top collision");
                    moving[0].CollisionResponseTop(other[j]);
                    other[j].CollisionResponseBottom(moving[0]);
                }
                ClippingCorrection(j, other);
            }
            //ClippingCorrection(j, other);
            else if (overlap.Height > overlap.Width && overlap.Width > 0)
            {
                //ClippingCorrection(j, other);
                int difleft = overlap.X - moving[0].BoundingBox.X;
                int difright = (moving[0].BoundingBox.X + moving[0].BoundingBox.Width) - overlap.X;
                Debug.WriteLine("difleft = " + difleft);
                Debug.WriteLine("difright = " + difright);
                if (difleft > difright && moving[0].BoundingBox.X < other[j].BoundingBox.X)
                {
                    //colliding with the right side of moving
                    //Debug.WriteLine("right horizontal collision");
                    moving[0].CollisionResponseSide(other[j]);
                    other[j].CollisionResponseSide(moving[0]);
                }
                else if ((moving[0].BoundingBox.X + moving[0].BoundingBox.Width) > (other[j].BoundingBox.X + other[j].BoundingBox.Width))
                {
                    //colliding with the left side of moving
                    //Debug.WriteLine("left horizontal collision");
                    moving[0].CollisionResponseSide(other[j]);
                    other[j].CollisionResponseSide(moving[0]);
                }
            }
            
        }

        public void ClippingCorrection(int j, List<ICollidable> other)
        {
            if (((other[j].BoundingBox.Y + other[j].BoundingBox.Height) - moving[0].BoundingBox.Y) < ((moving[0].BoundingBox.Y + moving[0].BoundingBox.Height) - other[j].BoundingBox.Y))
            {
                if (((moving[0].BoundingBox.X + moving[0].BoundingBox.Width) - other[j].BoundingBox.X) < ((other[j].BoundingBox.Y + other[j].BoundingBox.Height) - moving[0].BoundingBox.Y))
                {
                    moving[0].UpdatePosition((int)other[j].BoundingBox.X - (int)moving[0].BoundingBox.Width, (int)moving[0].Position.Y);
                    //moving[0].Position.X = new Vector2((int)other[j].BoundingBox.X - (int)moving[0].BoundingBox.Width, moving[0].Position.Y);
                    //Debug.WriteLine("1. bad!");
                }
                else if (((other[j].BoundingBox.X + other[j].BoundingBox.Width) - moving[0].BoundingBox.X) < ((other[j].BoundingBox.Y + other[j].BoundingBox.Height) - moving[0].BoundingBox.Y))
                {
                    moving[0].UpdatePosition((int)other[j].BoundingBox.X + (int)other[j].BoundingBox.Width, (int)moving[0].Position.Y);
                    //moving[0].Position.X = (int)other[j].BoundingBox.X + (int)other[j].BoundingBox.Width;
                    //Debug.WriteLine("2. bad!");
                }
                else
                {
                    moving[0].UpdatePosition((int)moving[0].Position.X, (int)other[j].BoundingBox.Y + (int)other[j].BoundingBox.Height);
                    //moving[0].Position.Y = (int)other[j].BoundingBox.Y + (int)other[j].BoundingBox.Height;
                }
            }
            else
            {
                if (((moving[0].BoundingBox.X + moving[0].BoundingBox.Width) - other[j].BoundingBox.X) < ((moving[0].BoundingBox.Y + moving[0].BoundingBox.Height) - other[j].BoundingBox.Y))
                {
                    moving[0].UpdatePosition((int)other[j].BoundingBox.X - (int)moving[0].BoundingBox.Width, (int)moving[0].Position.Y);
                    //moving[0].Position.X = (int)other[j].BoundingBox.X - (int)moving[0].BoundingBox.Width;
                    //Debug.WriteLine("3. bad!");
                }
                else if (((other[j].BoundingBox.X + other[j].BoundingBox.Width) - moving[0].BoundingBox.X) < ((moving[0].BoundingBox.Y + moving[0].BoundingBox.Height) - other[j].BoundingBox.Y))
                {
                    moving[0].UpdatePosition((int)other[j].BoundingBox.X + (int)other[j].BoundingBox.Width, (int)moving[0].Position.Y);
                    //moving[0].Position.X = (int)other[j].BoundingBox.X + (int)other[j].BoundingBox.Width;
                    //Debug.WriteLine("4. bad!");
                }
                else
                {
                    //This is where the problem is!!!
                    moving[0].UpdatePosition((int)moving[0].Position.X, (int)other[j].BoundingBox.Y - (int)moving[0].BoundingBox.Height);
                    //moving[0].Position.Y = (int)other[j].BoundingBox.Y - (int)moving[0].BoundingBox.Height;
                    //Debug.WriteLine("correction gives y value of: " + moving[0].Position.Y);
                }
            }
        }
    }
}
