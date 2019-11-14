using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Observer_Pattern
{
    interface ICameraSubject
    {
        void AttachObserver(ICameraObserver o);
        void DetachObserver(ICameraObserver o);
    }
}
