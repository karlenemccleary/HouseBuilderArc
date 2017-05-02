using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Desert : Location
    {
        private static Desert d;
        public Desert() : base(5000) {
            
        }

        public Desert(double price) : base(price)
        {

        }

        public static Desert createInstance()
        {
            if (d != null)
            {
                return d;
            }
            else
            {
                d = new Desert();
                return d;
            }
        }

        public static Desert createInstance(double price)
        {
            if (d != null)
            {
                return d;
            }
            else
            {
                d = new Desert(price);
                return d;
            }
        }
    }
}
