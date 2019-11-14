using Sprint_4.Models;
using Sprint_4.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_4.Sprites;

namespace Sprint_4.Commands
{
    //Commands to test whether the state changes of blocks are working properly
    //class BumpCommand : ICommand
    //{
    //    private BlockModel receiver;
    //    public BumpCommand(BlockModel receiver)
    //    {
    //        this.receiver = receiver;
    //    }
    //    public void Execute()
    //    {
    //        receiver.CurrentState.BumpTransition();
    //    }
    //}
    //class ExplodeCommand : ICommand
    //{
    //    private BlockModel receiver;
    //    public ExplodeCommand(BlockModel receiver)
    //    {
    //        this.receiver = receiver;
    //    }
    //    public void Execute()
    //    {
    //        receiver.CurrentState.ExplodedTransition();
    //    }
    //}

    class FeatureToggleCommand : ICommand
    {
        private MarioModel receiver;
        public FeatureToggleCommand(MarioModel receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.FeatureOn = !receiver.FeatureOn;
        }
    }


}
