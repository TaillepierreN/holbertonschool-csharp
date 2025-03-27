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
		hp -= damage;
	}

	/// <summary>
	/// heal damage method
	/// </summary>
	/// <param name="heal"></param>
	public void HealDamage(float heal)
	{
		heal = heal >= 0 ? heal : 0;
		Console.WriteLine("{0} heals {1} HP!", name, heal);
		hp += heal;
	}
}
