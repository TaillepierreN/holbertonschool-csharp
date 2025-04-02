using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using InventoryLibrary;

namespace InventoryLibrary
{
    public class JSONStorage
    {
        private const string StorageDir = "storage";
        private const string FileName = "inventory_manager.json";
        private string FilePath;

        public Dictionary<string, string> objects { get; set; }

        public JSONStorage()
        {
            FilePath = Path.Combine(StorageDir, FileName);
            objects = new Dictionary<string, string>();
        }

        public Dictionary<string, string> All()
        {
            return objects;
        }

        public void New(BaseClass obj)
        {
            string id = obj.GetType().GetProperty("id")?.GetValue(obj)?.ToString();
            if (id != null)
            {
                string key = $"{obj.GetType().Name}.{id}";
                if (objects.ContainsKey(key))
                    throw new ArgumentException($"Object with key {key} already exists.");
                string jsonString = JsonSerializer.Serialize(obj, obj.GetType()); ;
                objects[key] = jsonString;
            }
            else
            {
                throw new ArgumentException("Object does not have a valid ID.");
            }
        }

        public void Save()
        {
            if (!Directory.Exists(StorageDir))
                Directory.CreateDirectory(StorageDir);

            string json = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public void Load()
        {
            if (!File.Exists(FilePath))
                return;
            string json = File.ReadAllText(FilePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                objects = new Dictionary<string, string>();
                return;
            }
            objects = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
        }

        public T GetObject<T>(string key)
        {
            if (objects.ContainsKey(key))
            {
                try
                {
                    Console.WriteLine($"Attempting to deserialize key: {key}");
                    return JsonSerializer.Deserialize<T>(objects[key]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Deserialization error for key {key}: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Key {key} does not exist in objects.");
            }

            return default;
        }

    }

}