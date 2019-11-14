using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Sprites
{
    class AvatarPowerState : IStates
    {
        public bool isVisible;
        public AvatarPowerState()
        {
            isVisible = false;
        }
        public void Update()
        {
            isVisible = true;     
        }
    }
}
