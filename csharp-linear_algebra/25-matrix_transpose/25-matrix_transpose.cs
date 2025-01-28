using System;

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

        if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            return new double[0, 0];

        double[,] result = new double[matrix.GetLength(1), matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < ùatrix.GetLength(1); j++)
                result[j, i] = matrix[i, j];
        return result;
    }
}

