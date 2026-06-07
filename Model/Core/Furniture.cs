using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Model.Core
{
    [XmlInclude(typeof(Chair))]
    [XmlInclude(typeof(Table))]
    [XmlInclude(typeof(Sofa))]
    [XmlInclude(typeof(Bed))]
    [XmlInclude(typeof(Armchair))]
    [XmlInclude(typeof(Stool))]
    public abstract class Furniture
    {
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        public decimal _basePrice;
        public int Id { get; set; } 
        public string Article {  get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ImagePath { get; set; }
        public virtual decimal Price //для наследников
        {
            get
            {
                return _basePrice;
            }
        }
        public Furniture()
        {

        }
        protected Furniture(int id,string article, string brand, string model,string name,decimal basePrice,string imagePath)
        {
            Id = id;
            Article = article;
            Brand = brand;
            Model = model;
            Name = name;
            ImagePath = imagePath;
            _basePrice = basePrice;
        }
        public override string ToString()
        {
            return $"{Brand} {Model} ({Article}) - {Price}₽";
        }
    }
}
