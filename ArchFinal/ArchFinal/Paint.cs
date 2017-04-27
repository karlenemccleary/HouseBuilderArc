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
        Color color;
        public Paint(Color color) : base(30)
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
    }
}
