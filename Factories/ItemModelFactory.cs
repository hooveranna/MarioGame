using Microsoft.Xna.Framework.Graphics;
using Sprint_4.States;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_4.Models;
using Microsoft.Xna.Framework;
using Sprint_4.Collision;

namespace Sprint_4.Sprites
{
    public class ItemModelFactory
    {

        ItemEnemySpriteFactory ItemEnemySpriteFactory;
        Vector2 Coordinates;
        Vector2 Velocity;
        CollisionGrid CollisionGrid;

        //Item Factory constructor
        public ItemModelFactory(ItemEnemySpriteFactory itemEnemySpriteFactory,CollisionGrid collisionGrid)
        {
            ItemEnemySpriteFactory = itemEnemySpriteFactory;
            CollisionGrid = collisionGrid;
        }

        //Overload method for item
        public ItemModel GetItemModel(string type, Vector2 coordinates, Vector2 velocity)
        {

            Coordinates = coordinates;
            Velocity = velocity;
            ItemModel itemModel = null;
            if (type.Equals("fireflower"))
            {
                itemModel = new FireFlowerModel(ItemEnemySpriteFactory, Coordinates, Velocity, CollisionGrid);
            }
            else if (type.Equals("coin"))
            {
                itemModel = new CoinModel(ItemEnemySpriteFactory, Coordinates, Velocity);
            }
            else if (type.Equals("redmushroom"))
            {
                itemModel = new RedMushroomModel(ItemEnemySpriteFactory, Coordinates, Velocity,CollisionGrid);
            }
            else if (type.Equals("greenmushroom"))
            {
                itemModel = new GreenMushroomModel(ItemEnemySpriteFactory, Coordinates, Velocity,CollisionGrid);
            }
            else if (type.Equals("star"))
            {
                itemModel = new SuperStarModel(ItemEnemySpriteFactory, Coordinates, Velocity, CollisionGrid);
            }
            return itemModel;
        }




    }
}
