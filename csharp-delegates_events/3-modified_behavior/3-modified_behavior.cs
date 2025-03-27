using System;

/// <summary>
/// Player class
/// </summary>
class Player
{
	/*player name*/
	private string name;
	/*player max hp*/
	private float maxHp;
	/*playe hp*/
	private float hp;

	/// <summary> CalculateHealth delegate</summary>
	public delegate void CalculateHealth(float amount);

	/// <summary>
	/// player constructor
	/// </summary>
	/// <param name="name"></param>
	/// <param name="maxHp"></param>
	public Player(string name = "Player", float maxHp = 100f)
	{
		this.name = name;
		if (maxHp <= 0)
		{
			this.maxHp = 100f;
			Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
		}
		else
		{
			this.maxHp = maxHp;
		}
		this.hp = this.maxHp;
	}

	/// <summary>
	/// print player health
	/// </summary>
	public void PrintHealth()
	{
		Console.WriteLine($"{name} has {hp} / {maxHp} health");
	}

	/// <summary>
	/// take damage method
	/// </summary>
	/// <param name="damage"></param>
	public void TakeDamage(float damage)
	{
		damage = damage >= 0 ? damage : 0;
		Console.WriteLine("{0} takes {1} damage!", name, damage);
		ValidateHP(hp - damage);
	}

	/// <summary>
	/// heal damage method
	/// </summary>
	/// <param name="heal"></param>
	public void HealDamage(float heal)
	{
		heal = heal >= 0 ? heal : 0;
		Console.WriteLine("{0} heals {1} HP!", name, heal);
		ValidateHP(hp += heal);
	}

	/// <summary>
	/// validate hp
	/// </summary>
	/// <param name="newHp"></param>
	public void ValidateHP(float newHp)
	{
		switch (newHp)
		{
			case float health when health < 0:
				hp = 0;
				break;
			case float health when health > maxHp:
				hp = maxHp;
				break;
			default:
				hp = newHp;
				break;
		}
	}

	/// <summary>
	/// ApplyModifier method
	/// </summary>
	/// <param name="baseValue"></param>
	/// <param name="modifier"></param>
	/// <returns></returns>
	public float ApplyModifier(float baseValue, Modifier modifier)
	{
		switch (modifier)
		{
			case Modifier.Weak:
				return baseValue * 0.5f;
			case Modifier.Base:
				return baseValue;
			case Modifier.Strong:
				return baseValue * 1.5f;
			default:
				return baseValue;
		}
	}
}

	/// <summary>
	/// Modifier enum
	/// </summary>
	public enum Modifier
	{
		Weak,
		Base,
		Strong
	}

	/// <summary>
	/// CalculateModifier delegate
	/// </summary>
	/// <param name="baseValue"></param>
	/// <param name="modifier"></param>
	/// <returns></returns>
	public delegate float CalculateModifier(float baseValue, Modifier modifier);