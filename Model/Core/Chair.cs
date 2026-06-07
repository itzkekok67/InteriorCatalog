using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public class Chair : Furniture
    {
        public bool HasArmrests { get; set; }
        public int LegsCount { get; set; }

        public Chair() { }
        public Chair(int id, string article, string brand, string model, string name, decimal basePrice, string imagePath, bool hasArmrests,int legsCount) : base(id, article, brand, model, name, basePrice, imagePath)
        {
            HasArmrests = hasArmrests;
            LegsCount = legsCount;
        }
        public override decimal Price
        {
            get
            {
                decimal price = _basePrice;
                if (HasArmrests)
                {
                    price += 1500;
                }

                price += LegsCount * 200;
                return price;
            }
        }
    }
}
