using System;
using InventoryLibrary;
using System.Linq;
using System.Text.Json;

class Program
{
    static InventoryLibrary.JSONStorage storage = new InventoryLibrary.JSONStorage();

    static void Main(string[] args)
    {
        storage.Load();

        while (true)
        {
            InitialPrompt();
            Console.Write("\n> ");
            string input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input))
                continue;

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0].ToLower();

            switch (command)
            {
                case "classnames":
                    ClassNames();
                    break;
                case "all":
                    if (parts.Length == 1) ShowAll();
                    else ShowAll(parts[1]);
                    break;
                case "create":
                    if (parts.Length == 2) Create(parts[1]);
                    else InvalidInput();
                    break;
                case "show":
                    if (parts.Length == 3) Show(parts[1], parts[2]);
                    else InvalidInput();
                    break;
                case "update":
                    if (parts.Length == 3) Update(parts[1], parts[2]);
                    else InvalidInput();
                    break;
                case "delete":
                    if (parts.Length == 3) Delete(parts[1], parts[2]);
                    else InvalidInput();
                    break;
                case "exit":
                    return;
                default:
                    InvalidInput();
                    break;
            }
        }
    }

    static void InitialPrompt()
    {
        Console.WriteLine(@"
Inventory Manager
-------------------------
<ClassNames> show all ClassNames of objects
<All> show all objects
<All [ClassName]> show all objects of a ClassName
<Create [ClassName]> a new object
<Show [ClassName object_id]> an object
<Update [ClassName object_id]> an object
<Delete [ClassName object_id]> an object
<Exit>");
    }

    static void ClassNames()
    {
        var classNames = storage.All().Keys
            .Select(k => k.Split('.')[0])
            .Distinct(StringComparer.OrdinalIgnoreCase);

        foreach (var name in classNames)
            Console.WriteLine(name);
    }

    static void ShowAll(string className = null)
    {
        foreach (var pair in storage.All())
        {
            if (className == null || pair.Key.StartsWith(className + ".", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }

    static void Create(string className)
    {
        BaseClass obj = null;
        className = className.ToLower();

        try
        {
            switch (className)
            {
                case "user":
                    Console.Write("Enter name: ");
                    obj = new User(Console.ReadLine());
                    break;

                case "item":
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    var item = new Item { name = name };
                    Console.Write("Enter description (optional): ");
                    item.description = Console.ReadLine();
                    Console.Write("Enter price (optional): ");
                    if (float.TryParse(Console.ReadLine(), out float price))
                        item.price = (float)Math.Round(price, 2);
                    obj = item;
                    break;

                case "inventory":
                    Console.Write("Enter user_id: ");
                    string userId = Console.ReadLine();
                    Console.Write("Enter item_id: ");
                    string itemId = Console.ReadLine();
                    Console.Write("Enter quantity (default 1): ");
                    int quantity = int.TryParse(Console.ReadLine(), out int q) ? q : 1;
                    obj = new Inventory(userId, itemId, quantity);
                    break;

                default:
                    Console.WriteLine($"{className} is not a valid object type");
                    return;
            }

            storage.New(obj);
            storage.Save();
            Console.WriteLine("Object created.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating object: {ex.Message}");
        }
    }

    static void Show(string className, string id)
    {
        className = className.ToLower();
        string key = $"{className}.{id}";

        string match = storage.objects.Keys.FirstOrDefault(k =>
            k.Equals(key, StringComparison.OrdinalIgnoreCase)
        );

        if (match == null)
        {
            Console.WriteLine($"Object {id} could not be found");
            return;
        }

        switch (className)
        {
            case "user":
                var user = storage.GetObject<User>(match);
                if (user != null)
                    Console.WriteLine($"User: {user.name} (id: {user.id})");
                else
                    Console.WriteLine($"Object {id} could not be found");
                break;

            case "item":
                if (storage.objects.TryGetValue(match, out string rawJson))
                {
                    var item = JsonSerializer.Deserialize<Item>(rawJson);
                    if (item != null)
                        Console.WriteLine($"Item: {item.name}\nDescription: {item.description}\nPrice: {item.price}\nID: {item.id}");
                    else
                        Console.WriteLine($"Object {id} could not be found");
                }
                else
                {
                    Console.WriteLine($"Object {id} could not be found");
                }
                break;

            case "inventory":
                var inv = storage.GetObject<Inventory>(match);
                if (inv != null)
                    Console.WriteLine($"Inventory:\nUser ID: {inv.user_id}\nItem ID: {inv.item_id}\nQuantity: {inv.quantity}");
                else
                    Console.WriteLine($"Object {id} could not be found");
                break;

            default:
                Console.WriteLine($"{className} is not a valid object type");
                break;
        }
    }

    static void Update(string className, string id)
    {
        string match = storage.objects.Keys.FirstOrDefault(k =>
            k.Equals($"{className}.{id}", StringComparison.OrdinalIgnoreCase));

        if (match == null)
        {
            Console.WriteLine($"Object {id} could not be found");
            return;
        }

        var json = storage.objects[match];

        switch (className.ToLower())
        {
            case "user":
                var user = DeserializeObject<User>(json);
                if (user == null)
                {
                    Console.WriteLine($"Object {id} could not be found");
                    return;
                }
                Console.Write($"Current name is '{user.name}', enter new name: ");
                user.name = Console.ReadLine();
                storage.objects[match] = JsonSerializer.Serialize(user);
                break;

            case "item":
                var item = DeserializeObject<Item>(json);
                if (item == null)
                {
                    Console.WriteLine($"Object {id} could not be found");
                    return;
                }
                Console.Write($"Current name is '{item.name}', enter new name: ");
                item.name = Console.ReadLine();
                Console.Write($"Current description is '{item.description}', enter new description: ");
                item.description = Console.ReadLine();
                Console.Write($"Current price is '{item.price}', enter new price: ");
                if (float.TryParse(Console.ReadLine(), out float p)) item.price = p;
                storage.objects[match] = JsonSerializer.Serialize(item);
                break;

            case "inventory":
                var inv = DeserializeObject<Inventory>(json);
                if (inv == null)
                {
                    Console.WriteLine($"Object {id} could not be found");
                    return;
                }
                Console.Write($"Current quantity is '{inv.quantity}', enter new quantity: ");
                if (int.TryParse(Console.ReadLine(), out int newQty)) inv.quantity = newQty;
                storage.objects[match] = JsonSerializer.Serialize(inv);
                break;

            default:
                Console.WriteLine($"{className} is not a valid object type");
                return;
        }

        storage.Save();
        Console.WriteLine("Object updated.");
    }

    static void Delete(string className, string id)
    {
        string match = storage.objects.Keys.FirstOrDefault(k =>
            k.Equals($"{className}.{id}", StringComparison.OrdinalIgnoreCase));

        if (match == null)
        {
            Console.WriteLine($"Object {id} could not be found");
            return;
        }

        if (storage.objects.Remove(match))
        {
            storage.Save();
            Console.WriteLine("Object deleted.");
        }

    }

    static void InvalidInput()
    {
        Console.WriteLine("Invalid input. Try again.");
    }

    static T DeserializeObject<T>(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Deserialization error: {ex.Message}");
            return default;
        }
    }
}
