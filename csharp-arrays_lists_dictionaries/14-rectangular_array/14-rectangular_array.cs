using System;


class Program
{
    static void Main(string[] args)
    {
        int sideSize = 5;
        int[,] square = new int[sideSize,sideSize];
        square[2,2] = 1;

        for (int i = 0; i < sideSize; i++)
        {
            for (int j = 0; j < sideSize; j++)
            {
                if (j == sideSize - 1)
                {
                    Console.Write(square[i,j]);
                    break;
                }
                Console.Write($"{square[i,j]} ");
            }
            Console.WriteLine();
        }
    }
}

