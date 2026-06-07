using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Interface
{
    public interface IFurnitureCatalog
    {
        void Add(Furniture furniture);
        void Add(Furniture[] furnitures);
        void Remove(string article);
        void Remove(Type type); //универсально для всех предметов
    }
}
