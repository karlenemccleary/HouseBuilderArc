using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    abstract class AbsHouseParts : HousePartsIF
    {
        private double price;

        public AbsHouseParts(double price)
        {
            this.price = price;
        }

        public double getPrice()
        {
            return price;
        }
        
    }
}
