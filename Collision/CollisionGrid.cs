using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Models;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Collision
{
    public class CollisionGrid
    {
        private List<ICollidable> allCollidables;
        private List<GridSquare> gridSquares;
        private int width = 0;
        private int height = 0;
        private int rows = 6;
        private int columns = 10;
        private int boxWidth;
        private int boxHeight;
        private Boolean drawBoxes = false;

        public CollisionGrid()
        {
            //this.graphicsDevice = g;
           // this.spriteBatch = spriteBatch;
            this.boxWidth = this.width / this.columns;
            this.boxHeight = this.height / this.rows;
            this.allCollidables = new List<ICollidable>();
            this.gridSquares = new List<GridSquare>();
            for(int i = 0; i < rows * columns; i++)
            {
                gridSquares.Add(new GridSquare());
            }
        }
        public void AddCollidable(ICollidable collidable)
        {
            allCollidables.Add(collidable);
        }

        public void RemoveCollidable(ICollidable collidable)
        {
            allCollidables.Remove(collidable);
        }

        public void Update()
        {
            UpdateGridSquares();
            DetectAndHandleCollisions();
        }

        /*

        public void Draw()
        {
            if (this.drawBoxes)
            {
                foreach (ICollidable collidable in allCollidables)
                {
                    Color boxColor = Color.White;
                    if(collidable is BlockModel)
                    {
                        boxColor = Color.Blue;
                    }
                    else if(collidable is EnemyModel)
                    {
                        boxColor = Color.Red;
                    }
                    else if(collidable is ItemModel)
                    {
                        boxColor = Color.Green;
                    }
                    else if(collidable is MarioModel)
                    {
                        boxColor = Color.Yellow;
                    }

                    Texture2D rect = new Texture2D(graphicsDevice, collidable.BoundingBox.Width, collidable.BoundingBox.Height);

                    Color[] data = new Color[collidable.BoundingBox.Width * collidable.BoundingBox.Height];
                    for (int i = 0; i < data.Length; ++i) data[i] = boxColor;
                        rect.SetData(data);

                    Vector2 coor = new Vector2(collidable.BoundingBox.X, collidable.BoundingBox.Y);
                    spriteBatch.Draw(rect, coor, Color.White);
                }
                
            }
        }
        */

        public void UpdateGridSquares()
        {
            //Clear grid
            for (int i = 0; i < rows * columns; i++)
            {
                gridSquares[i] = new GridSquare();
            }

            foreach (ICollidable collidable in this.allCollidables)
            {
                Rectangle boundingBox = collidable.BoundingBox;
                int leftMostColumn = boundingBox.X / this.boxWidth;
                int rightMostColumn = (boundingBox.X + boundingBox.Width) / this.boxWidth;
                int upperMostRow = boundingBox.Y / this.boxHeight;
                int lowerMostRow = (boundingBox.Y + boundingBox.Height) / this.boxHeight;

                for (int i = leftMostColumn; i <= rightMostColumn; i++)
                {
                    for (int j = upperMostRow; j <= lowerMostRow; j++)
                    {
                        if (i >= 0 && i < this.columns && j >= 0 && j < this.rows)
                        {
                            this.gridSquares[i + (j * this.columns)].AddCollidable(collidable);
                        }
                    }
                }

            }
        }

        public void DetectAndHandleCollisions()
        {
            for(int i = 0; i < this.gridSquares.Count; i++)
            {
                gridSquares[i].HandleCollisions();
            }
        }

        public void ToggleCollisionBoxes()
        {
            this.drawBoxes = !this.drawBoxes;
        }

        public void UpdateDimensions(int newWidth, int newHeight)
        {
            this.width = newWidth;
            this.height = newHeight;
            this.boxWidth = this.width / this.columns;
            this.boxHeight = this.height / this.rows;
        }

        public void OnMarioDeath(object source, EventArgs args)
        {
            ICollidable mario = null;
            foreach(ICollidable c in allCollidables)
            {
                if(c is MarioModel)
                mario = c;
            }
            RemoveCollidable(mario);
        }



    }
}
