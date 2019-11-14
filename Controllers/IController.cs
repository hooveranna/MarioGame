using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_4.Commands;

namespace Sprint_4.Controllers
{
    interface IController
    {
        void AddCommand(char character, ICommand newCommand);
        void AddHoldCommand(char character, ICommand newCommand);
        void Update();
    }
}
