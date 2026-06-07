using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Model.Data
{
    public abstract class AbstractSerializer
    {
        public abstract void Save(string path, Furniture[] items);
        public abstract Furniture[] Load(string path);
    }
}
