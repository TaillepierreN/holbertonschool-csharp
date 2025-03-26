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
	int Durability { get; set; }
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
/// test object
/// </summary>
class TestObject : Base, IInteractive, IBreakable, ICollectable
{
	/// <summary>Durability property</summary>
	public int Durability { get; set; }
	/// <summary>isCollected property</summary>
	public bool isCollected { get; set; }

	/// <summary>
	/// Interact method
	/// </summary>
	public void Interact()
	{
		///empty
	}

	/// <summary>
	/// Break method
	/// </summary>
	public void Break()
	{
		///empty
	}

	/// <summary>
	/// Collect method
	/// </summary>
	public void Collect()
	{
		///empty

	}
}