using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Observer_Pattern
{
    public class MarioEventArgs : EventArgs
    {
        public int Points { get; set; }
        public int Coins { get; set; }
        public int Lives { get; set; }
        public int Time { get; set; }

        public override bool Equals(object obj)
        {
            if(!(obj is MarioEventArgs))
            {
                return false;
            }
            MarioEventArgs args = (MarioEventArgs)obj;
            if(Points != args.Points || Coins != args.Coins || Lives != args.Lives || Time != args.Time)
            {
                return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
