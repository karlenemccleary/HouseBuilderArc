using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class PaintHASS : PaintAndWindow
    {
        private static PaintHASS paint;
        Color color;
        public PaintHASS(Color color) : base(30)
        {
            this.color = color;
        }

        public PaintHASS(Color color, double price) : base(price)
        {
            this.color = color;
        }

        public Color PaintColor
        {
            set
            {
                color = value;
            }
            get
            {
                return color;
            }
        }

        public static PaintHASS createInstance()
        {
            if (paint != null)
            {
                return paint;
            }
            else
            {
                paint = new PaintHASS(Color.Blue);
                return paint;
            }
        }

        public static PaintHASS createInstance(Color color, double price)
        {
            if (paint != null)
            {
                return paint;
            }
            else
            {
                paint = new PaintHASS(Color.Blue, price);
                return paint;
            }
        }
    }
}
