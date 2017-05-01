using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Window : PaintAndWindow
    {
        public Window() : base(400)
        {
        }

        public Window(double price) : base(price)
        {

        }
    }
}
