using System;

class Program
{
    static void Main(string[] args)
    {
        Random rndm = new Random();
        int number = rndm.Next(-10000, 10000);
        string result;

        if (number % 10 > 5)
            result = "is greater than 5";
        else if (number % 10 == 0)
            result = "is 0";
        else
            result = "is less than 6 and not 0";

        Console.WriteLine($"The last digit of {number} is {number % 10} and {result}");
    }
}