using System;

public class Number
{
    public static int PrintLastDigit(int number)
    {
        int lastDigit = number % 10;
        if (lastDigit < 0)
            lastDigit *= -1;
        Console.Write(lastDigit);

        return lastDigit;
    }
}