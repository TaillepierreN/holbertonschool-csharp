using System;
using System.Collections.Generic;

class List
{
    public static int SafePrint(List<int> myList, int n)
    {
        int numberOfPrint = 0;
        while (numberOfPrint < n)
        {
            try
            {
                Console.WriteLine(myList[numberOfPrint]);
            }
            catch (ArgumentOutOfRangeException)
            {
                break;
            }
            numberOfPrint++;
        }
        return numberOfPrint;
    }
}

