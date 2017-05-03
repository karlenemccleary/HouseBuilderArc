using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Location : LocationIF
    {
        double price;

        public Location(double price) {
            this.price = price;
        }

        public Location()
        {
            
        }

        public double getPrice() {
            return price;
        }
    }
}
