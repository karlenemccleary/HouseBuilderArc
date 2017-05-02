using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Oceanside : Location
    {
        private static Oceanside o;
        public Oceanside() : base(80000){
            
        }

        public Oceanside(double price) : base(price)
        {

        }

        public static Oceanside createInstance()
        {
            if (o != null)
            {
                return o;
            }
            else
            {
                o = new Oceanside();
                return o;
            }
        }

        public static Oceanside createInstance(double price)
        {
            if (o != null)
            {
                return o;
            }
            else
            {
                o = new Oceanside(price);
                return o;
            }
        }
    }
}
