using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class PrivateIsland : Location
    {
        private static PrivateIsland p;
        public PrivateIsland(): base(1000000) {
            
        }

        public PrivateIsland(double price) : base(price)
        {

        }

        public static PrivateIsland createInstance()
        {
            if (p != null)
            {
                return p;
            }
            else
            {
                p = new PrivateIsland();
                return p;
            }
        }

        public static PrivateIsland createInstance(double price)
        {
            if (p != null)
            {
                return p;
            }
            else
            {
                p = new PrivateIsland(price);
                return p;
            }
        }
    }
}
