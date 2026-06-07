using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public class Sofa : Furniture
    {
        public int SeatsCounts { get; set; } //сколько человек поместятся
        public bool IsCorner { get; set; } //угловой
        public Sofa() { }
        public Sofa(int id, string article, string brand, string model, string name, decimal basePrice, string imagePath, bool isCorner, int seatsCount) : base(id, article, brand, model, name, basePrice, imagePath)
        {
            SeatsCounts = seatsCount;
            IsCorner = isCorner;
        }
        public override decimal Price
        {
            get
            {
                decimal price = _basePrice;
                price += SeatsCounts * 3000;
                if (IsCorner) price += 5000;
                return price;
            }
        }
    }
}
