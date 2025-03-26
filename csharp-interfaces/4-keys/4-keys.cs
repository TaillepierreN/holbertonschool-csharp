using System;

/// <summary>
/// Base class
/// </summary>
abstract class Base
{
	/// <summary>Name property</summary>
	public string name { get; set; }

	/// <summary>ToString override</summary>
	public override string ToString()
	{
		return $"{name} is a {GetType().Name}";
	}
}

/// <summary>
/// interface interactive
/// </summary>
interface IInteractive
{
	void Interact();
}

/// <summary>
/// interface breakable
/// </summary>
interface IBreakable
{
	int durability { get; set; }
	void Break();
}

/// <summary>
/// interface collectable
/// </summary>
interface ICollectable
{
	bool isCollected { get; set; }
	void Collect();
}

/// <summary>
/// door class
/// </summary>
class Door : Base, IInteractive
{

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="name"></param>
	public Door(string name = "Door")
	{
		this.name = name;
	}

	/// <summary>
	/// Interact method
	/// </summary>
	public void Interact()
	{
		Console.WriteLine($"You try to open the {name}. It's locked.");
	}

}

class Decoration : Base, IInteractive, IBreakable
{
	/// <summary>isQuestItem property</summary>
	public bool isQuestItem { get; set; }
	/// <summary>durability property</summary>
	public int durability { get; set; }

	/// <summary>
	/// Constructor
	/// </summary>
	public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false)
	{
		if (durability <= 0)
			throw new Exception("Durability must be greater than 0");
		this.name = name;
		this.durability = durability;
		this.isQuestItem = isQuestItem;
	}

	/// <summary>
	/// Interact method
	/// </summary>
	public void Interact()
	{
		if (durability <= 0)
			Console.WriteLine($"The {name} has been broken.");
		else if (isQuestItem)
			Console.WriteLine($"You look at the {name}. There's a key inside.");
		else
			Console.WriteLine($"You look at the {name}. Not much to see here.");
	}

	/// <summary>
	/// break method
	/// </summary>
	public void Break()
	{
		durability--;
		if (durability > 0)
			Console.WriteLine($"You hit the {name}. It cracks.");
		else if (durability == 0)
			Console.WriteLine($"You smash the {name}. What a mess.");
		else
			Console.WriteLine($"The {name} is already broken.");
	}

}

/// <summary>
/// Key class
/// </summary>
class Key : Base, ICollectable
{
	/// <summary>isCollected property</summary>
	public bool isCollected { get; set; }

	/// <summary>
	/// Constructor
	/// </summary>
	public Key(string name = "Key", bool isCollected = false)
	{
		this.name = name;
		this.isCollected = isCollected;
	}

	/// <summary>
	/// Collect method
	/// </summary>
	public void Collect()
	{
		if (!isCollected)
		{
			isCollected = true;
			Console.WriteLine($"You pick up the {name}.");
		}
		else
			Console.WriteLine($"You have already picked up the {name}.")
	}
}