﻿using System;

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if(i % 5 == 0 && i % 3 == 0)
                    Console.Write("FizzBuzz");
                else if(i % 5 == 0)
                    Console.Write("Buzz");
                else if (i % 3 == 0)
                    Console.Write("Fizz");
                else
                    Console.Write(i);
                if (i == 100)
                    Console.WriteLine("");
                else
                    Console.Write(" ");
            };
        }
    }

