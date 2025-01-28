using System;

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
            return new double[,] { { -1 } };

        double[,] result = new double[matrixRows, matrixCols];
        double[,] shear = new double[2, 2] {{1, 0}, {0, 1}};

        if (direction == 'x')
            shear[1, 0] = factor;
        else if (direction == 'y')
            shear[0, 1] = factor;

        for (int i = 0; i < matrixRows; i++)
        {
            for (int j = 0; j < matrixCols; j++)
            {
                for (int k = 0; k < 2; k++)  
                    result[i, j] += (matrix[i, k] * shear[k, j]);
            }
        }
        return result;
    }
}
