using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Location : LocationIF
    {
        int price;

        public Location(int price) {
            this.price = price;
        }

        public int getPrice() {
            return price;
        }
    }
}
