using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Composite : AbsHouseParts
    {
        List<PaintAndWindow> pw;
        public Composite(double price) : base(price)
        {
            pw = new List<PaintAndWindow>();
        }
    }
}
