using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Model.Data
{
    public class XmlSerialize : AbstractSerializer
    {
        public override Furniture[] Load(string path)
        {
            if (!File.Exists(path))
            {
                return new Furniture[0];
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Furniture[]));

            using (StreamReader reader = new StreamReader(path))
            {
                Furniture[] items = (Furniture[])serializer.Deserialize(reader);

                if (items == null)
                {
                    return new Furniture[0];
                }

                return items;
            }
        }

        public override void Save(string path, Furniture[] items)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Furniture[]));

            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, items);
            }
        }
    }
}
