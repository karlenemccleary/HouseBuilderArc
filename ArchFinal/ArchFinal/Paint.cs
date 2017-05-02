using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class Paint : PaintAndWindow
    {
        private static Paint paint;
        Color color;
        public Paint(Color color) : base(30)
        {
            this.color = color;
        }

        public Paint(Color color, double price) : base(price)
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

        public static Paint createInstance()
        {
            if (paint != null)
            {
                return paint;
            }
            else
            {
                paint = new Paint(Color.Blue);
                return paint;
            }
        }

        public static Paint createInstance(Color color, double price)
        {
            if (paint != null)
            {
                return paint;
            }
            else
            {
                paint = new Paint(Color.Blue, price);
                return paint;
            }
        }
    }
}
