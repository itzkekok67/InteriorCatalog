using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public class Armchair : Chair
    {
        public bool HasGenuineLeather { get; set; }
        public Armchair() { }
        public Armchair(int id, string article, string brand, string model, string name, decimal basePrice, string imagePath, bool hasGenuineLeather, bool hasArmrests, int legsCount) : base(id, article, brand, model, name, basePrice, imagePath, hasArmrests, legsCount)
        {
            HasGenuineLeather = hasGenuineLeather;
        }
        public override decimal Price
        {
            get
            {
                decimal price = base.Price;
                if (HasGenuineLeather)
                {
                    price += 1200;
                }
                return price;
            }
        }

    }
}
