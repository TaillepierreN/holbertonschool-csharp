using System;

/// <summary>
/// class for matrix math
/// </summary>
class MatrixMath
{
    /// <summary>
    /// rotate a 2d matrix given an angle in radians
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        int matrixRows = matrix.GetLength(0);
        int matrixCols = matrix.GetLength(1);

        if (matrixRows != 2 || matrixCols != 2)
            return new double[,] { { -1 } };

        double[,] rotate = new double[2, 2] { { Math.Cos(angle), Math.Sin(angle) }, { -1 * Math.Sin(angle), Math.Cos(angle) } };

        if (matrixCols != rotate.GetLength(0))
            return new double[,] { { -1 } };

        double[,] result = new double[matrixRows, rotate.GetLength(1)];

        for (int i = 0; i < matrixRows; i++)
        {
            for (int j = 0; j < rotate.GetLength(1); j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < matrixRows; k++)
                    result[i, j]  += matrix[i, k] * rotate[k, j];
                result[i, j] = Math.Round(result[i, j], 2);
            }
        }
        return result;
    }
}
