using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class ItemStandardState : ItemStates
    {
        public ItemStandardState(ItemModel item) : base(item)
        {

            Item.IsAnimated = true;
        }
        public override void Enter(IItemStates previousState)
        {
            CurrentState = this;
            PreviousState = previousState;
            Item.Color = Color.White;
        }
        //If consumed, changed color
        public override void ConsumedTransition()
        {
            CurrentState.ExitState();
            CurrentState = new ItemConsumedState(Item);
            CurrentState.Enter(this);
        }
    }
}
