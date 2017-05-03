using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    interface ObservableIF
    {
        void addObserver(Builder b);
        void removeObserver();
    }
}
