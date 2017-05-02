using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Country : Location
    {
        private static Country country;
        public Country() : base(50000) {

        }

        public Country(double price) : base(price)
        {

        }

        public static Country createInstance()
        {
            if (country != null)
            {
                return country;
            }
            else
            {
                country = new Country();
                return country;
            }
        }

        public static Country createInstance(double price)
        {
            if (country != null)
            {
                return country;
            }
            else
            {
                country = new Country(price);
                return country;
            }
        }
    }
}
