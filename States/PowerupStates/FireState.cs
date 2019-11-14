/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States.PowerupStates
{
    class FireState : IPowerupState
    {

        public int CollisionPositionFactor { get; set; }
        private static FireState instance = null;
        private FireState()
        {

            CollisionPositionFactor = 1;
        }

        public static FireState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FireState();
                }
                return instance;
            }
        }
        public IPowerupState TakeDamage()
        {
            return SuperState.Instance;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
*/