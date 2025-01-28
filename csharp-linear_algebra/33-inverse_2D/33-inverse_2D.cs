using System;

/// <summary>
/// class for matrix math
/// </summary>
class MatrixMath
{
    public static double[,] Inverse2D(double[,] matrix)
    {
        int matrixRows = matrix.GetLength(0);
        int matrixCols = matrix.GetLength(1);

        if (matrixRows != 2 || matrixCols != 2)
            return new double[,] { { -1 } };

        double determinant = (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
        if (determinant == 0)
            return new double[,] {{-1}};

        double[,] result = new double[2, 2];
        result[0, 0] = Math.Round((matrix[1, 1] / determinant), 2);
        result[0, 1] = Math.Round((-matrix[0, 1] / determinant),)2;
        result[1, 0] = Math.Round((-matrix[1, 0] / determinant), 2);
        result[1, 1] =  Math.Round((matrix[0, 0] / determinant),2);

        return result;
    }
}
