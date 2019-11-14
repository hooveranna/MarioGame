using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint_4.Commands;
using System.Diagnostics;

namespace Sprint_4.Controllers
{
    class GamePadController : IController
    {
        private Dictionary<char, ICommand> commands;
        private Dictionary<char, ICommand> holdCommands;
        GamePadState previousState;

        public GamePadController()
        {
            this.commands = new Dictionary<char, ICommand>();
            this.holdCommands = new Dictionary<char, ICommand>();
            previousState = GamePad.GetState(PlayerIndex.One);
            //empty = new GamePadState(Vector2.Zero, Vector2.Zero, 0, 0, new Buttons());
        }
        public void AddCommand(char character, ICommand newCommand)
        {
            commands.Add(character, newCommand);
            Debug.WriteLine(commands.Count + " Commands in 'commands'");
        }
        public void AddHoldCommand(char character, ICommand newCommand)
        {
            holdCommands.Add(character, newCommand);
        }

        public void Update()
        {
            List<PlayerIndex> players = new List<PlayerIndex>
            {
                PlayerIndex.One,
                PlayerIndex.Two,
                PlayerIndex.Three,
                PlayerIndex.Four
            };
            foreach (PlayerIndex player in players)
            {
                GamePadState currentState = GamePad.GetState(player);
                if (currentState.IsConnected)
                {
                    var buttonList = (Buttons[])Enum.GetValues(typeof(Buttons));
                    foreach(var button in buttonList)
                    {
                        if (currentState.IsButtonDown(button))
                        {
                            if (!previousState.IsButtonDown(button))
                            {
                                if (commands.ContainsKey((char)button))
                                {
                                    commands[(char)button].Execute();
                                    Debug.WriteLine(button.ToString() + " Executed from GamePad!");
                                }
                                Debug.WriteLine(button.ToString() + " Pressed from GamePad!");
                            } 
                        }
                        else if (previousState.IsButtonDown(button))
                        {
                            if (holdCommands.ContainsKey((char)button))
                            {
                                holdCommands[(char)button].Execute();
                            }
                            Debug.WriteLine(button.ToString() + " Released from GamePad!");
                        }
                    }
                    previousState = currentState;
                }
            }
        }
    }
}
