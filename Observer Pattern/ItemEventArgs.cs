using Sprint_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4.Observer_Pattern
{
    public class ItemEventArgs : EventArgs
    {
        public ItemModel Item { get; set; }
    }
}
