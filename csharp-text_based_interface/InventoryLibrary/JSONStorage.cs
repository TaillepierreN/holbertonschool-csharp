using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class JSONStorage
{
    private const string StorageDir = "storage";
    private const string FileName = "inventory_manager.json";
    private string FilePath;

    public Dictionary<string, BaseClass> objects { get; set; }

    public JSONStorage()
    {
        FilePath = Path.Combine(StorageDir, FileName);
        objects = new Dictionary<string, BaseClass>();
    }

    public Dictionary<string, BaseClass> All()
    {
        return objects;
    }

    public void New(BaseClass obj)
    {
        string key = $"{obj.GetType().Name}.{obj.id}";
        if (objects.ContainsKey(key))
            throw new ArgumentException($"Object with key {key} already exists.");
        objects[key] = obj;
    }

    public void Save()
    {
        if (!Directory.Exists(StorageDir))
            Directory.CreateDirectory(StorageDir);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            TypeInfoResolver = new CustomResolver()
        };

        string json = JsonSerializer.Serialize(objects, options);
        File.WriteAllText(FilePath, json);
    }

    public void Load()
    {
        if (!File.Exists(FilePath))
            return;

        var options = new JsonSerializerOptions
        {
            TypeInfoResolver = new CustomResolver()
        };

        string json = File.ReadAllText(FilePath);
        objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(json) ?? new Dictionary<string, BaseClass>();
    }
    private class CustomResolver : DefaultJsonTypeInfoResolver
    {
        public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
        {
            if (type == typeof(BaseClass))
            {
                var ti = base.GetTypeInfo(type, options);
                ti.PolymorphismOptions = new JsonPolymorphismOptions
                {
                    TypeDiscriminatorPropertyName = "$type",
                    IgnoreUnrecognizedTypeDiscriminators = true
                };
                ti.PolymorphismOptions.DerivedTypes.Add(new JsonDerivedType(typeof(Item), nameof(Item)));
                ti.PolymorphismOptions.DerivedTypes.Add(new JsonDerivedType(typeof(User), nameof(User)));
                ti.PolymorphismOptions.DerivedTypes.Add(new JsonDerivedType(typeof(Inventory), nameof(Inventory)));
                return ti;
            }

            return base.GetTypeInfo(type, options);
        }
    }
}

