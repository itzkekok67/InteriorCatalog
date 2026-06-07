using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public class Table : Furniture
    {
        public int SeatsCounts { get; set; } //сколько человек поместятся
        public bool HasDrawers { get; set; } //наличие ящиков
        public Table() { }
        public Table(int id, string article, string brand, string model, string name, decimal basePrice, string imagePath, bool hasDrawers, int seatsCount) : base(id, article, brand, model, name, basePrice, imagePath)
        {
            SeatsCounts = seatsCount;
            HasDrawers = hasDrawers;
        }
        public override decimal Price
        {
            get
            {
                decimal price = _basePrice;
                price += SeatsCounts * 500;
                if (HasDrawers) price += 2000;
                return price;
            }
        }
    }
}
