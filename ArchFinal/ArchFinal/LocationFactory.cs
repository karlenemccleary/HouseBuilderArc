using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class LocationFactory
    {
        public LocationIF getLocation(string str) {
            str = "ArchFinal." + str;
            Type type = Type.GetType(str, true);
            object o = Activator.CreateInstance(type);
            return (LocationIF)o;
        }
    }
}
