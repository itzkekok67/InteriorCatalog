using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public partial class FurnitureCatalog
    {
        public void PrioritySort()
        {
            for (int i = 0; i < Items.Length - 1; i++)
            {
                for (int j = 0; j < Items.Length - 1 - i; j++)
                {
                    bool swap = false;
                    int brand = CompareStrings(Items[j].Brand, Items[j+1].Brand);
                    if (brand > 0)
                    {
                        swap = true;
                    }
                    else if (brand == 0)
                    {
                        int model = CompareStrings(Items[j].Model, Items[j+1].Model);
                        if (model > 0)
                        {
                            swap = true;
                        }
                        else if (model == 0)
                        {
                            int name = CompareStrings(Items[j].Name, Items[j+1].Name);
                            if (name > 0)
                            {
                                swap = true;
                            }
                            else if (name  == 0)
                            {
                                int article = CompareStrings(Items[j].Article, Items[j+1].Article);
                                if (article > 0)
                                {
                                    swap = true;
                                }
                            }
                        }
                    }
                    if (swap)
                    {
                        (Items[j], Items[j+1]) = (Items[j+1],  Items[j]);
                    }
                }   
            }
        }
    }
}
