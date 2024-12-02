using System;

namespace _4_print_hexa
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (i <= 98)
            {
                Console.WriteLine($"{i} = 0x{i:x}\n");
                i++;
            }
        }
    }
}
