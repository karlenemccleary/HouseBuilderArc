using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Country : Location
    {
        public Country() : base(50000) {

        }

        public Country(double price) : base(price)
        {

        }
    }
}
