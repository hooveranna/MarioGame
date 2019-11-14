using Microsoft.Xna.Framework;
using Sprint_4.Models;
using Sprint_4.States;
using System;

namespace Sprint_4.States
{
    class ItemConsumedState : ItemStates
    {
        public ItemConsumedState(ItemModel item) : base(item)
        {
        }
        public override void Enter(IItemStates previousState)
        {
            Item.Time.Start();
            Item.IsAnimated = false;
            CurrentState = this;
            PreviousState = previousState;
            Item.IsVisible = false;
            Item.Velocity = new Vector2(0,0);
            //Item.MoveAwayFactor = new Vector2(0, 0);
            //Send the item's collision box out of the face of the earth
            //Item.ConsumedPositionFactor = 0;
        }

    }
}
