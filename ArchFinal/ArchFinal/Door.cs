using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Door : Composite
    {
        public Door() : base(300)
        {
        }

        public Door(double price) : base(price)
        {
        }
    }
}
