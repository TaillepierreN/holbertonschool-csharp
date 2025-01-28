using System;

/// <summary>
/// class for matrix math
/// </summary>
class MatrixMath
{
    public static double[,] Shear2D(double[,] matrix, char direction, double factor)
    {
        int matrixRows = matrix.GetLength(0);
        int matrixCols = matrix.GetLength(1);

        if(matrixRows != matrixCols || matrixRows != 2 || (direction != 'x' && direction != 'y'))
            returnnew double[,] {{-1}};
        
        double[,] shearMatrix;
        if(direction == 'x')
        {
            shearMatrix = new double[,] {{1, factor}, {0, 1}}
        }
        else
        {
            shearMatrix = new double[,] {{1, 0}, {factor, 1}}
        }

        double[,] result = new double[matrixRows, matrixCols];
        for (int i = 0; i < matrixRows; i++)
        {
            for (int j = 0; j < matrixCols; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < matrixCols; k++)
                    result[i, j] += shearMatrix[i, k] * matrix[k, j];
            }
        }
        return result;
    }
}
