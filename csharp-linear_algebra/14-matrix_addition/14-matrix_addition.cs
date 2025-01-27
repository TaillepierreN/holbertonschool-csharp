using System;

/// <summary>
/// class for matrix math
/// </summary>
    class MatrixMath
    {
        /// <summary>
        /// add two matrices
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        public static double[,] Add(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.Length != matrix2.Length || matrix1.Length < 2 || matrix1.Length > 3)
                return new double[,] { {-1}};
            
            double[,] result = new double[matrix1.Length, matrix1.Length];
            for (int i = 0; i < matrix1.Length; i++)
                for (int y = 0; y < matrix1.Length; y++)
                    result[i, y] = matrix1[i, y] + matrix2[i, y];
            return result;
        }
    }

