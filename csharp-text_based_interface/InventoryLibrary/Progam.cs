using System;

public class Program
{
	public static void Main()
	{
		var storage = new JSONStorage();

		var user = new User("Aerith Gainsborough");
		var item = new Item("Silver Staff");
		var inv = new Inventory(user.id, item.id);

		storage.New(user);
		storage.New(item);
		storage.New(inv);

		storage.Save();
		storage.Load();

		foreach (var obj in storage.All())
		{
			Console.WriteLine($"{obj.Key} => {obj.Value.GetType().Name}");
		}
	}
}