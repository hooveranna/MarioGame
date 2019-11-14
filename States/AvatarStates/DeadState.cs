using Sprint_0.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Sprites
{
    class DeadState : IStates
    {
        AvatarSprite avatarSprite;
        public DeadState(AvatarSprite avatar)
        {
            avatarSprite = avatar;
            avatarSprite.isDead = false;
            
        }
        public void Update()
        {
            avatarSprite.isDead = true;
        }
    }
}
