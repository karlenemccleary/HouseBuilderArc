using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class City : Location
    {
        private static City city;
        public City() : base(20000) {
            
        }

        public City(double price) : base(price)
        {

        }

        public static City createInstance()
        {
            if (city != null)
            {
                return city;
            }
            else
            {
                city = new City();
                return city;
            }
        }

        public static City createInstance(double price)
        {
            if (city != null)
            {
                return city;
            }
            else
            {
                city = new City(price);
                return city;
            }
        }
    }
}
