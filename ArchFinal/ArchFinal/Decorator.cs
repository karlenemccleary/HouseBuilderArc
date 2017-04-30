using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Decorator : House
    {
        House house;
        LocationIF location;
        public Decorator(House h, LocationIF l) : base(h.getPrice() + l.getPrice()) {
            house = h;
            location = l;
        }

        public override double getPrice()
        {
            return house.getPrice() + location.getPrice();
        }

    }
}
