using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Roof : AbsHouseParts
    {
        private static Roof roof;
        private Roof() : base(2000)
        {

        }

        private Roof(double price) : base(price)
        {

        }

        public static Roof createInstance()
        {
            if (roof != null)
            {
                return roof;
            }
            else
            {
                roof = new Roof();
                return roof;
            }
        }

        public static Roof createInstance(double price) 
        {
            if (roof != null)
            {
                return roof;
            }
            else
            {
                roof = new Roof(price);
                return roof;
            }
        }
    }
}
