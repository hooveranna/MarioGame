using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Observer_Pattern
{
    interface ICameraObserver
    {
        void GetNotified(Rectangle r);
    }
}
