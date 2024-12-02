using System;

class Program
{
	static void Main(string[] args)
	{
		double percent = .7553;
		double currency = 98765.4321;
        Console.WriteLine(string.Format("Percent: {0:0.0%}", percent));
        Console.WriteLine(string.Format("Currency: {0:C2}", currency));
	}
}