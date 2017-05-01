using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Suburb : Location
    {
        public Suburb() : base(30000) {
            
        }

        public Suburb(double price) : base(price)
        {

        }
    }
}
