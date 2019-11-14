using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Commands
{
    public class ResetGameCommand : ICommand
    {
        private Game1 game;
        public ResetGameCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.ResetGame();
        }
    }

    public class PauseUnpauseGameCommand : ICommand
    {
        private Game1 game;
        public PauseUnpauseGameCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Paused = !game.Paused;
        }
    }
}
