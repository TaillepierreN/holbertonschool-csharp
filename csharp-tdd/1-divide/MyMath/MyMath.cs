using System;

namespace MyMath
{
    /// <summary>
    /// Matrix class
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Divide matrix by num
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int[,] Divide(int[,] matrix, int num)
        {
            if (matrix == null)
                return null;

            int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            try
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int y = 0; y < matrix.GetLength(1); y++)
                        newMatrix[i, y] = matrix[i, y] / num;
                }
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Num cannot be zero");
                return null;
            }
            return newMatrix;
        }
    }
}
