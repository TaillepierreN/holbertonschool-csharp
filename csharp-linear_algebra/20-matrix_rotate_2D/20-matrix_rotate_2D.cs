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

        if (matrixRows != matrixCols || matrixRows < 2)
            return new double[,] { { -1 } };

        double cosTheta = Math.Cos(angle);
        double sinTheta = Math.Sin(angle);
        
        double[,] result = new double[matrixRows, matrixCols];

        for (int i = 0; i < matrixRows; i++)
        {
            for (int j = 0; j < matrixCols; j++)
            {
                int newX = (int)(cosTheta * i - sinTheta * j);
                int newY = (int)(sinTheta * i + cosTheta * j);

                if (newX >= 0 && newX < matrixRows && newY >= 0 && newY < matrixCols)
                {
                    result[newX, newY] = matrix[i, j];
                }
            }
        }
        return result;
    }
}
