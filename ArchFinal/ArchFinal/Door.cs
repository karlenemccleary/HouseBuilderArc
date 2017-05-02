using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Door : Composite
    {
        private static Door door;
        public Door() : base(300)
        {
        }

        public Door(double price) : base(price)
        {
        }

        public static Door createInstance()
        {
            if (door != null)
            {
                return door;
            }
            else
            {
                door = new Door();
                return door;
            }
        }

        public static Door createInstance(double price)
        {
            if (door != null)
            {
                return door;
            }
            else
            {
                door = new Door(price);
                return door;
            }
        }
    }
}
