﻿using System;

/// <summary>
/// class for matrix math
/// </summary>
class MatrixMath
{
    /// <summary>
    /// Transpose a matrix
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public static double[,] Transpose(double[,] matrix)
    {
        double[,] result = new double[matrix.GetLength(1), matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < ùatrix.GetLength(1); j++)
                result[j, i] = matrix[i, j];
        return result;
    }
}

