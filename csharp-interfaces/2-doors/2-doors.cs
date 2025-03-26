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