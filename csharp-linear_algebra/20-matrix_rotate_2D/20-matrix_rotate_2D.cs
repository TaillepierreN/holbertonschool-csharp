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
        int matrixSize = matrix.GetLength(0);

        if(matrixSize != matrix.GetLength(1))
            return new double[,] {{-1}};

        double[,] result = new double[matrixSize, matrixSize];
        double cosAngle = Math.Cos(angle);
        double sinAngle = Math.Sin(angle);

        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
                result[i, j] = Math.Round(cosAngle * matrix[i, j] - sinAngle * matrix[j, i], 2);
        }

        return result;
    }
}
