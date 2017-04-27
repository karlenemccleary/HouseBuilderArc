using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class House : HouseIF
    {
        private double price;
        private HousePartsIF part;

        House()
        {
            price = part.getPrice();
        }

        public double getPrice()
        {
            return price;
        }
    }
}
