﻿using System;

/// <summary>
/// class for matrix math
/// </summary>
class MatrixMath
{
    /// <summary>
    /// shear a 2d matrix given a direction and a factor
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="direction"></param>
    /// <param name="factor"></param>
    /// <returns></returns>
    public static double[,] Shear2D(double[,] matrix, char direction, double factor)
    {
        int matrixRows = matrix.GetLength(0);
        int matrixCols = matrix.GetLength(1);

        if (matrixRows != matrixCols || matrixRows != 2 || (direction != 'x' && direction != 'y'))
            return new double[,] { { -1} };

        double[,] result = new double[matrixRows, matrixCols];
        
        for (int i = 0; i < matrixRows; i++)
        {
            for (int j = 0; j < matrixCols; j++)
            {
                if (direction == 'x')
                    result[i, j] = matrix[i, j] + factor * matrix[i, j];
                else if (direction == 'y')
                    result[i, j] = matrix[i, j] + factor * matrix[i, j];
            }
        }
        return result;
    }
}
