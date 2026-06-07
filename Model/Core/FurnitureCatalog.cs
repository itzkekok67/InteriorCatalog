using Model.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public partial class FurnitureCatalog : IFurnitureCatalog, ISortable
    {
        public string Name { get; set; }
        public string Season { get; set; }
        public Furniture[] Items { get; set; }
        public FurnitureCatalog()
        {
            Items = new Furniture[0];
        }
        public static FurnitureCatalog operator +(FurnitureCatalog catalog, Furniture item)
        {
            Furniture[] newArr = new Furniture[catalog.Items.Length + 1];

            for (int i = 0; i < catalog.Items.Length; i++)
                newArr[i] = catalog.Items[i];

            newArr[newArr.Length - 1] = item;

            catalog.Items = newArr;
            return catalog;
        }
        public Furniture[] Filter(Func<Furniture, bool> predicate)
        {
            return Items.Where(predicate).ToArray();
        }

        // Predicate версия
        public Furniture[] Find(Predicate<Furniture> predicate)
        {
            return Items.Where(x => predicate(x)).ToArray();
        }

        // Action (логирование)
        public void ForEach(Action<Furniture> action)
        {
            foreach (var item in Items)
                action(item);
        }
    }
}
