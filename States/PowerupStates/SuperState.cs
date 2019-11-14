/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States.PowerupStates
{
    class SuperState : IPowerupState
    {
        public int CollisionPositionFactor { get; set; }
        private static SuperState instance = null;
        private SuperState()
        {

            CollisionPositionFactor = 1;
        }

        public static SuperState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SuperState();
                }
                return instance;
            }
        }
        public IPowerupState TakeDamage()
        {
            return StandardState.Instance;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
*/