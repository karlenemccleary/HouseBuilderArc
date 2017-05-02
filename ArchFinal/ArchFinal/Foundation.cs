using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Foundation : AbsHouseParts
    {
        private static Foundation foundation;
        public Foundation() : base(7000)
        {
        }

        public Foundation(double price) : base(price)
        {

        }

        public static Foundation createInstance()
        {
            if (foundation != null)
            {
                return foundation;
            }
            else
            {
                foundation = new Foundation();
                return foundation;
            }
        }

        public static Foundation createInstance(double price)
        {
            if (foundation != null)
            {
                return foundation;
            }
            else
            {
                foundation = new Foundation(price);
                return foundation;
            }
        }
    }
}
