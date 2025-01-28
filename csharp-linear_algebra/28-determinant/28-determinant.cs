using System;

/// <summary>
/// class for matrix math
/// </summary>
class MatrixMath
{
    public static double Determinant(double[,] matrix)
    {
        if (matrix == null || (matrix.GetLength(0) != 2 && matrix.GetLength(0) != 3))
            return -1;

        int matrixRows = matrix.GetLength(0);
        int matrixCols = matrix.GetLength(1);

        if (matrixRows == 2 && matrixCols == 2)
            return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
        

        else if (matrixRows == 3 && matrixCols == 3)
        {
            double a = matrix[0, 0], b = matrix[0, 1], c = matrix[0, 2];
            double d = matrix[1, 0], e = matrix[1, 1], f = matrix[1, 2];
            double g = matrix[2, 0], h = matrix[2, 1], i = matrix[2, 2];

            return a * (e * i - f * h) - b * (d * i - f * g) + c * (d * h - e * g);
        }
        return -1;
    }
}

