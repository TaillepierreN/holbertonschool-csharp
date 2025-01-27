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
            int matrix1RowLength = matrix1.GetLength(0);
            int matrix2RowLength = matrix2.GetLength(0);
            int matrix1ColLength = matrix1.GetLength(1);
            int matrix2ColLength = matrix2.GetLength(1);

            if (matrix1RowLength != matrix2RowLength  || matrix1ColLength != matrix2ColLength || (matrix1RowLength != 2 && matrix1RowLength != 3))
                return new double[,] { {-1}};
            
            double[,] result = new double[matrix1RowLength, matrix1ColLength];
            for (int i = 0; i < matrix1RowLength; i++)
                for (int y = 0; y < matrix1ColLength; y++)
                    result[i, y] = matrix1[i, y] + matrix2[i, y];
            return result;
        }
    }

