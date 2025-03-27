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
}
