using Microsoft.Xna.Framework.Input;
using Sprint_4.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sprint_4.Controllers
{
    class KeyboardController : IController
    {
        private Dictionary<char, ICommand> commands;
        private Dictionary<char, ICommand> holdCommands;
        KeyboardState previousKeyboardState;
        public KeyboardController()
        {
            this.commands = new Dictionary<char, ICommand>();
            this.holdCommands = new Dictionary<char, ICommand>();
            previousKeyboardState = Keyboard.GetState();
        }

        public void AddCommand(char character, ICommand newCommand)
        {
            commands.Add(character, newCommand);
        }
        public void AddHoldCommand(char character, ICommand newCommand)
        {
            holdCommands.Add(character, newCommand);
        }

        public void Update()
        {
            
            KeyboardState currentState = Keyboard.GetState();    

            Keys[] keysPressed = currentState.GetPressedKeys();
            foreach (Keys key in keysPressed) {
                if (!previousKeyboardState.IsKeyDown(key))
                {
                    if (commands.ContainsKey((char)key))
                    {
                        commands[(char)key].Execute();
                    }
                    Debug.WriteLine(key.ToString() + " Pressed!");
                } 
                
            }
            Keys[] keysReleased = previousKeyboardState.GetPressedKeys();
            foreach (Keys key in keysReleased)
            {
                if (!currentState.IsKeyDown(key))
                {
                    if (holdCommands.ContainsKey((char)key))
                    {
                        holdCommands[(char)key].Execute();
                        Debug.WriteLine(key.ToString() + " Released!");
                    }
                }

            }
            previousKeyboardState = currentState;
        }
    }
}
