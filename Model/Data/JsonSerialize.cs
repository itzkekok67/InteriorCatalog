using Model.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;

namespace Model.Data
{
    public class JsonSerialize : AbstractSerializer
    {
        public override void Save(string path, Furniture[] items)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings(); //как именно сериализовать
            settings.Formatting = Formatting.Indented;
            settings.TypeNameHandling = TypeNameHandling.Auto; //сохранять информацию о типе

            string json = JsonConvert.SerializeObject(items, settings);
            File.WriteAllText(path, json);
        }
        public override Furniture[] Load(string path)
        {
            if (!File.Exists(path))
            {
                return new Furniture[0];
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;

            string json = File.ReadAllText(path);

            Furniture[] items = JsonConvert.DeserializeObject<Furniture[]>(json, settings);

            if (items == null)
            {
                return new Furniture[0];
            }

            return items;
        }
    }
}
