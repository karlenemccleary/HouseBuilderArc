using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Siding : Composite
    {
        private static Siding siding;
        private static PaintAndWindow pw;
        public Siding() : base(5000)
        {

        }

        public Siding(double price) : base(price)
        {

        }

        public static Siding createInstance()
        {
            if (siding != null)
            {
                return siding;
            }
            else
            {
                siding = new Siding();
                return siding;
            }
        }

        public static Siding createInstance(double price)
        {
            if (siding != null)
            {
                return siding;
            }
            else
            {
                siding = new Siding(price);
                return siding;
            }
        }

    }
}
