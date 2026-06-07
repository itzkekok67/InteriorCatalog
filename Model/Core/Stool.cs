using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public class Stool : Chair
    {
        public bool HasWheels { get; set; }
        public Stool() { }
        public Stool(int id, string article, string brand, string model, string name, decimal basePrice, string imagePath, bool hasWheels, bool hasArmrests, int legsCount) : base(id, article, brand, model, name, basePrice, imagePath, hasArmrests, legsCount)
        {
            HasWheels = hasWheels;
        }
        public override decimal Price
        {
            get
            {
                decimal price = base.Price;
                if (HasWheels)
                {
                    price += 1000;
                }
                return price;
            }
        }
    }
}
