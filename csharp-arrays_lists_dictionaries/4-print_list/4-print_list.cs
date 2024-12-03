using System;
using System.Collections.Generic;

class List
{
    public static List<int> CreatePrint(int size)
    {
        
        List<int> list = new List<int>();

        if (size < 0)
        {
            Console.WriteLine("Size cannot be negative");
            return null;
        }
        if (size == 0)
        {
            Console.WriteLine("");
            return list;
        }

        for (int i = 0; i < size; i++)
        {
            list.Add(i);
            if (i == size - 1)
            {
                Console.WriteLine(i);
                break;
            }
            Console.Write($"{i} ");
        };
        return list;
    }
}

