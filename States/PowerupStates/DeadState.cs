/*using Sprint_4.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States.PowerupStates
{

    class DeadState : IPowerupState //dead :(
    {

        public int CollisionPositionFactor { get; set; }
        private static DeadState instance = null;
        private DeadState()
        {
            CollisionPositionFactor = 0;
        }

        public static DeadState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DeadState();
                    instance.CollisionPositionFactor = 0;
                }
                return instance;
            }
        }



        public IPowerupState TakeDamage()
        {
            return this;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
*/