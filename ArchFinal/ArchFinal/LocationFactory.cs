using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class LocationFactory
    {
        public LocationIF getLocation(string str, double price) {
            try
            {
                str = "ArchFinal." + str;
                Type type = Type.GetType(str, true);
                object o = Activator.CreateInstance(type, price);
                return (LocationIF)o;
            }
            catch(Exception e){
                return new Location(0);
            }
        }
    }
}
