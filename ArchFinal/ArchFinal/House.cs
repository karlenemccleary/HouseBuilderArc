using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFinal
{
    class House : ObservableIF
    {
        private double price;
        private List<HousePartsIF> parts;

        public House()
        {
            parts = new List<HousePartsIF>();
            price = 0;
        }

        public House(double price)
        {
            this.price = price;
        }

       // public void setPrice(HousePartsIF part) {
            
            //price += parts.getPrice();
        //}

        public virtual double getPrice()
        {
            return price;
        }

        public void addPart(HousePartsIF part, double mult)
        {
            parts.Add(part);
            price += part.getPrice() * mult;
        }

        public void removePart(HousePartsIF part)
        {
            parts.Remove(part);
            price -= part.getPrice();
        }

        public void removeObserver()
        {
            
        }

        public void addObserver(Builder b)
        {
            b.notify();
        }
    }
}
