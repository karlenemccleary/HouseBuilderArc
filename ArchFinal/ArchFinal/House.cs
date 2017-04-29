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

        public House()
        {
            price = 0;
        }

        public void setPrice() {
            price += part.getPrice();
        }

        public void setPart(HousePartsIF part)
        {
            this.part = part;
        }

        public double getPrice()
        {
            return price;
        }
    }
}
