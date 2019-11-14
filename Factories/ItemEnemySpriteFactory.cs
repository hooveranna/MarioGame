using Microsoft.Xna.Framework.Graphics;
using Sprint_4.States;
using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Sprites
{
    public class ItemEnemySpriteFactory
    {
        private Texture2D FireFlowerItem;
        private Texture2D CoinItem;
        private Texture2D RedMushroomItem;
        private Texture2D GreenMushroomItem;
        private Texture2D StarItem;
        private Texture2D CoinStatic;

        private Texture2D GoombaEnemy;
        private Texture2D TurtleEnemy;
        private Texture2D PiranhaEnemy;

        //Item Factory constructor
        public ItemEnemySpriteFactory(Texture2D fireFlowerItem, Texture2D coinItem, Texture2D redMushroomItem, Texture2D greenMushroomItem, Texture2D starItem, Texture2D coinStatic)
        {
            FireFlowerItem = fireFlowerItem;
            CoinItem = coinItem;
            RedMushroomItem = redMushroomItem;
            GreenMushroomItem = greenMushroomItem;
            StarItem = starItem;
            CoinStatic = coinStatic;
        }

        //Enemy Factory constructor
        public ItemEnemySpriteFactory(Texture2D goombaEnemy, Texture2D turtleEnemy, Texture2D piranhaEnemy)
        {
            GoombaEnemy = goombaEnemy;
            TurtleEnemy = turtleEnemy;
            PiranhaEnemy = piranhaEnemy;
        }
        //Method for Enemies
        public Texture2D GetEnemySprite(string type)
        {
            Texture2D texture = null;
            if (type.Equals("goomba"))
            {
                texture = GoombaEnemy;
            }
            else if (type.Equals("turtle"))
            {
                texture = TurtleEnemy;
            }
            else if (type.Equals("piranha"))
            {
                texture = PiranhaEnemy;
            }

            return texture;
        }
        //Overload method for item
        public Texture2D GetItemSprite(string type)
        {
            Texture2D texture = null;
            if (type.Equals("fireflower"))
            {
                texture = FireFlowerItem;
            }
            else if (type.Equals("coin"))
            {
                texture = CoinItem;
            }
            else if (type.Equals("coinstatic"))
            {
                texture = CoinStatic;
            }
            else if (type.Equals("redmushroom"))
            {
                texture = RedMushroomItem;
            }
            else if (type.Equals("greenmushroom"))
            {
                texture = GreenMushroomItem;
            }
            else if (type.Equals("star"))
            {
                texture = StarItem;
            }
            return texture;
        }




        }
}
