using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Observer_Pattern
{
    public class CheckpointEventArgs : EventArgs
    {
        public Vector2 Coordinates { get; set; }
    }
}
