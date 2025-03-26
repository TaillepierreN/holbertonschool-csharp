using System;

/// <summary>
/// Base class
/// </summary>
abstract class Base
{
	/// <summary>
	/// Name property
	/// </summary>
	public string name {get; set;};

	/// <summary>
	/// ToString override
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return $"{name} is a {GetType().Name}";
	}
}

