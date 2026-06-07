using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Interface
{
    public interface ISortable
    {
        void Sort(bool ascending);
        void SortByName(bool ascending);
        void SortByPrice(bool ascending);
    }
}
