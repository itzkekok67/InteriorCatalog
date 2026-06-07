using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Model.Core
{
    public class Storage<T>
    {
        public List<T> Items { get; set; } = new();

        public void Add(T item)
        {
            Items.Add(item);
        }

        public void Remove(T item)
        {
            Items.Remove(item);
        }
    }
}
