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
        if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
            return new double[,] { { -1 } };

        double cosAngle = Math.Cos(angle);
        double sinAngle = Math.Sin(angle);

        double[,] rotationMatrix = new double[,]
        {
            { cosAngle, -sinAngle },
            { sinAngle, cosAngle }
        };

        double[,] result = new double[2, 2];

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < 2; k++)
                {
                    result[i, j] += matrix[i, k] * rotationMatrix[k, j];
                }
                result[i, j] = Math.Round(result[i, j], 2);
            }
        }

        return result;
    }
}
