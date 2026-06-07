using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public class Bed : Furniture
    {
        public string Size { get; set; }
        public bool HasStorageBox { get; set; } //ящики
        public Bed() { }
        public Bed(int id, string article, string brand, string model, string name, decimal basePrice, string imagePath, bool hasStorageBox, string size) : base(id, article, brand, model, name, basePrice, imagePath)
        {
            Size = size;
            HasStorageBox = hasStorageBox;
        }
        public override decimal Price
        {
            get
            {
                decimal price = _basePrice;
                if (Size == null)
                {
                    Size = "Single";
                }
                if (HasStorageBox) price += 4000;

                if (Size == "OneAndHalf")
                {
                    price += 2000;
                }
                else if (Size == "Double")
                {
                    price += 4000;
                }
                else if (Size == "King")
                {
                    price += 7000;
                }
                
                return price;
            }
        }
    }
}
