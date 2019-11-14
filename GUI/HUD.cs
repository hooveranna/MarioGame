using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_4.Observer_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.GUI
{
    public class HUD
    {
        public int points { get; set; }
        public int coins { get; set; }
        public int lives { get; set; }
        private int time;
        private SpriteBatch s;
        private SpriteFont font;

        public int Points { get => points; set => points = value; }
        public int Coins { get => coins; set => coins = value; }
        public int Lives { get => lives; set => lives = value; }

        public HUD(GraphicsDevice g, SpriteFont font)
        {
            Points = 0;
            Coins = 0;
            Lives = 0;
            time = 400;
            this.font = font;
            s = new SpriteBatch(g);
        }
        public void Draw()
        {
            s.Begin();
            s.DrawString(font, "Points: " + Points, new Vector2(450, 0), Color.White);
            s.DrawString(font, "Coins: " + Coins, new Vector2(600, 0), Color.White);
            s.DrawString(font, "Lives: " + Lives, new Vector2(700, 0), Color.White);
            s.DrawString(font, "Time: " + time, new Vector2(800, 0), Color.White);
            s.End();
        }

        public void OnMarioUpdated(object source, MarioEventArgs args)
        {
            this.Points = args.Points;
            this.Coins = args.Coins;
            this.Lives = args.Lives;
            this.time = args.Time;
        }
    }
}
