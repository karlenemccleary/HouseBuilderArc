using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Suburb : Location
    {
        private static Suburb s;
        public Suburb() : base(30000) {
            
        }

        public Suburb(double price) : base(price)
        {

        }

        public static Suburb createInstance()
        {
            if (s != null)
            {
                return s;
            }
            else
            {
                s = new Suburb();
                return s;
            }
        }

        public static Suburb createInstance(double price)
        {
            if (s != null)
            {
                return s;
            }
            else
            {
                s = new Suburb(price);
                return s;
            }
        }
    }
}
