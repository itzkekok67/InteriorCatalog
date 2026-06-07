using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public partial class FurnitureCatalog
    {
        public void Add(Furniture furniture)
        {
            Furniture[] newArr = new Furniture[Items.Length + 1];
            for (int i = 0; i < Items.Length; i++)
            {
                newArr[i] = Items[i];
            }
            newArr[Items.Length] = furniture;
            Items = newArr;
        }
        public void Add(Furniture[] furnitures)
        {
            for (int i = 0; i < furnitures.Length; i++)
            {
                Add(furnitures[i]);
            }
        }
        public void Remove(string article)
        {
            int count = 0;
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i].Article !=  article)
                {
                    count++;
                }
            }
            Furniture[] newArr = new Furniture[count];
            int ind = 0;
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i].Article != article)
                {
                    newArr[ind] = Items[i];
                    ind++;
                }
            }
            Items = newArr;
        }
        public void Remove(Type type)
        {
            int count = 0;
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i].GetType() != type)
                {
                    count++;
                }
            }
            Furniture[] newArr = new Furniture[count];
            int ind = 0;
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i].GetType() != type)
                {
                    newArr[ind] = Items[i];
                    ind++;
                }
            }
            Items = newArr;
        }
    }
}
