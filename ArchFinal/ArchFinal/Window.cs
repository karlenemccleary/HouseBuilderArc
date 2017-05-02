using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Window : PaintAndWindow
    {
        private static Window window;
        public Window() : base(400)
        {
        }

        public Window(double price) : base(price)
        {

        }

        public static Window createInstance()
        {
            if (window != null)
            {
                return window;
            }
            else
            {
                window = new Window();
                return window;
            }
        }

        public static Window createInstance(double price)
        {
            if (window != null)
            {
                return window;
            }
            else
            {
                window = new Window(price);
                return window;
            }
        }
    }
}
