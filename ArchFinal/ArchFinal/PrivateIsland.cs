using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class PrivateIsland : Location
    {
        public PrivateIsland(): base(1000000) {
            
        }

        public PrivateIsland(double price) : base(price)
        {

        }
    }
}
