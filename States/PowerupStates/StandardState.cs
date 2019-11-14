/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States.PowerupStates
{
    class StandardState : IPowerupState
    {
        public int CollisionPositionFactor { get; set; }
        private static StandardState instance = null;
        private StandardState()
        {
            CollisionPositionFactor = 1;
        }

        public static StandardState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StandardState();
                }
                return instance;
            }
        }
        public IPowerupState TakeDamage()
        {
            return DeadState.Instance;
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
*/