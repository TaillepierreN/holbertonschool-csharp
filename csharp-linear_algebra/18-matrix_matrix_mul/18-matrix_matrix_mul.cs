using System;

/// <summary>
/// class for matrix math
/// </summary>
class MatrixMath
    {
        /// <summary>
        /// Multiply two matrice
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
                return new double[,] { {-1}};
            
            double[,] result = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
                for (int y = 0; y < matrix2.GetLength(1); y++)
                    for (int z = 0; z < matrix1.GetLength(1); z++)
                        result[i, y] += matrix1[i, z] * matrix2[z, y];
            return result;
        }
    }

