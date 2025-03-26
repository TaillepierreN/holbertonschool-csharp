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

interface IInteractive
{
	void Interact();
}

interface IBreakable
{
	int Durability { get; set; }
	void Break();
}

interface ICollectable
{
	bool isCollected { get; set; }
	void Collect();
}

class TestObject : Base, IInteractive, IBreakable, ICollectable
{
	///EMpty
}