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
        result[0, 0] =  matrix[1, 1] / determinant;
        result[0, 1] = -matrix[0, 1] / determinant;
        result[1, 0] = -matrix[1, 0] / determinant;
        result[1, 1] =  matrix[0, 0] / determinant;

        return result;
    }
}
