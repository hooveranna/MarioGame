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
    public class EnemyModelFactory
    {

        ItemEnemySpriteFactory ItemEnemySpriteFactory;
        Vector2 Coordinates;
        Vector2 Velocity;
        //suppressed to allow for debugging features
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        CollisionGrid CollisionGrid;

        //Item Factory constructor
        public EnemyModelFactory(ItemEnemySpriteFactory itemEnemySpriteFactory, CollisionGrid collisionGrid)
        {
            ItemEnemySpriteFactory = itemEnemySpriteFactory;
            CollisionGrid = collisionGrid;
        }

        //Overload method for enemy
        public EnemyModel GetEnemyModel(string type, Vector2 coordinates, Vector2 velocity)
        {

            Coordinates = coordinates;
            Velocity = velocity;
            EnemyModel EnemyModel = null;
            if (type.Equals("goomba"))
            {
                EnemyModel = new GoombaEnemyModel(ItemEnemySpriteFactory, Coordinates, Velocity);
            }
            else if (type.Equals("turtle"))
            {
                EnemyModel = new TurtleEnemyModel(ItemEnemySpriteFactory, Coordinates, Velocity);
            }
            else if (type.Equals("piranha"))
            {
                EnemyModel = new PiranhaEnemyModel(ItemEnemySpriteFactory, Coordinates, Velocity);
            }
            return EnemyModel;
        }
    }
}
