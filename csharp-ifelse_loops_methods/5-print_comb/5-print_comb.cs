using System;

namespace _5_print_comb
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = "";
            for (int i = 0; i < 100; i++)
                output += $"{i:D2}{(i<99? ", " : "\n")}";
            Console.Write(output);
        }
    }
}
