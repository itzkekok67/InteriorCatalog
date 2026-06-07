using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public partial class FurnitureCatalog
    {
        private int CompareStrings(string str1, string str2)
        {
            int len;
            if (str1.Length <  str2.Length)
            {
                len = str1.Length;
            }
            else
            {
                len = str2.Length;
            }
            for (int i = 0; i < len; i++)
            {
                if (str1[i] > str2[i]) 
                    return 1;
                if (str1[i] < str2[i]) 
                    return -1;
            }
            if (str1.Length > str2.Length) 
                return 1;
            if (str1.Length < str2.Length)
                return -1;
            return 0;
        }
        public void Sort()
        {
            Sort(true);
        }
        public void Sort(bool ascending) //по артикулу
        {
            for (int i = 0; i < Items.Length - 1; i++)
            {
                for (int j = 0; j < Items.Length - 1 - i;  j++)
                {
                    int result = CompareStrings(Items[j].Article, Items[j+1].Article);
                    bool needSwap = false;
                    if (ascending) //по возрастанию
                    {
                        if (result == 1)
                        {
                            needSwap = true;
                        }
                    }
                    else //по убыванию
                    {
                        if (result == -1)
                        {
                            needSwap = true;
                        }
                    }
                    if (needSwap)
                    {
                        (Items[j], Items[j + 1]) = (Items[j + 1], Items[j]);
                    }
                }
            }
        }
        public void SortByName(bool ascending)
        {
            for (int i = 0; i < Items.Length - 1; i++)
            {
                for (int j = 0; j < Items.Length - 1 - i; j++)
                {
                    int result = CompareStrings(Items[j].Name, Items[j + 1].Name);
                    bool needSwap = false;
                    if (ascending) //по возрастанию
                    {
                        if (result == 1)
                        {
                            needSwap = true;
                        }
                    }
                    else //по убыванию
                    {
                        if (result == -1)
                        {
                            needSwap = true;
                        }
                    }
                    if (needSwap)
                    {
                        (Items[j], Items[j + 1]) = (Items[j + 1], Items[j]);
                    }
                }
            }
        }
        public void SortByPrice(bool ascending)
        {
            for (int i = 0; i < Items.Length - 1; i++)
            {
                for (int j = 0; j < Items.Length - 1 - i; j++)
                {
                    bool needSwap = false;
                    if (ascending) //по возрастанию
                    {
                        if (Items[j].Price > Items[j+1].Price)
                        {
                            needSwap = true;
                        }
                    }
                    else //по убыванию
                    {
                        if (Items[j].Price < Items[j+1].Price)
                        {
                            needSwap = true;
                        }
                    }
                    if (needSwap)
                    {
                        (Items[j], Items[j + 1]) = (Items[j + 1], Items[j]);
                    }
                }
            }
        }
    }
}
