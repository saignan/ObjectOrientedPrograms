using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Inventory_Management_Program
{
    public static class FileManager
    {
        public static string FilePath = "D:/inventory.json";
        public static void Save(Inventory inventory)
        {
            var json = JsonConvert.SerializeObject(inventory);
            if (!File.Exists(FilePath))
            {
                var stream = File.Create(FilePath);
                stream.Close();
            }
            File.WriteAllText(FilePath, json);
        }
        public static Inventory LoadInventory()
        {
            if (File.Exists(FilePath))
            {
                var stringContent = File.ReadAllText(FilePath);
                var inventoryObj = JsonConvert.DeserializeObject<Inventory>(stringContent);
                if (inventoryObj != null)
                {
                    return inventoryObj;
                }
            }
            return new Inventory();

        }
    }
}
