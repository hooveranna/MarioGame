using Sprint_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Commands
{
    class EnemyMoveLeft : ICommand
    {
        private EnemyModel receiver;
        public EnemyMoveLeft(EnemyModel receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.MoveLeft();
        }
    }
    class EnemyMoveRight : ICommand
    {
        private EnemyModel receiver;
        public EnemyMoveRight(EnemyModel receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.MoveRight();
        }
    }
/*
    class EnemyFall : ICommand
    {
        private EnemyModel receiver;
        public EnemyFall(EnemyModel receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.Fall();
        }
    }*/
    /*
        class InjureEnemyCommand : ICommand
        {
            private EnemyModel receiver;
            public InjureEnemyCommand(EnemyModel receiver)
            {
                this.receiver = receiver;
            }
            public void Execute()
            {
                receiver.CurrentState.InjuredTransition();
            }
        }
        class ConsumeItemCommand : ICommand
        {
            private ItemModel receiver;
            public ConsumeItemCommand(ItemModel receiver)
            {
                this.receiver = receiver;
            }
            public void Execute()
            {
                receiver.CurrentState.ConsumedTransition();
            }
        }*/
}
