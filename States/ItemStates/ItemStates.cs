using Microsoft.Xna.Framework;
using Sprint_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.States
{
    public abstract class ItemStates : IItemStates
    {

        public IItemStates PreviousState { get; set; }
        public ItemModel Item { get; set; }
        public IItemStates CurrentState { get { return Item.CurrentState; } set { Item.CurrentState = value; } }
        IItemStates IItemStates.PreviousState { get { return PreviousState; } }
        

        protected ItemStates(ItemModel item)
        {
            Item = item;
        }
        public virtual void Enter(IItemStates previousState)
        {
            CurrentState = this;
            PreviousState = previousState;
        }

        //Only Implement these methods inside each class that inherits this class if applicable
        public virtual void ExitState() { }

        public virtual void StandardTransition() { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void ConsumedTransition() { }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
