using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Desert : Location
    {
        public Desert() : base(5000) {
            
        }

        public Desert(double price) : base(price)
        {

        }
    }
}
