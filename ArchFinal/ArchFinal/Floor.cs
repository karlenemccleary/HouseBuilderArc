using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Floor : AbsHouseParts
    {
        private static Floor floor;
        public Floor() : base(1800)
        {

        }
        public Floor(double price) : base(price)
        {

        }

        public static Floor createInstance()
        {
            if (floor != null)
            {
                return floor;
            }
            else
            {
                floor = new Floor();
                return floor;
            }
        }

        public static Floor createInstance(double price)
        {
            if (floor != null)
            {
                return floor;
            }
            else
            {
                floor = new Floor(price);
                return floor;
            }
        }
    }
}
