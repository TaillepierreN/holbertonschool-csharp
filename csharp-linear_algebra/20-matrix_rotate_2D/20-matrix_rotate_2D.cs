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

        if (matrixRows != matrixCols || matrixRows != 2)
            return new double[,] {{-1}};
        
        double cosTheta = Math.Cos(angle);
        double sinTheta = Math.Sin(angle);
        double[,] rotateMatrix = new double[,]{{cosTheta, -sinTheta}, {sinTheta, cosTheta}};

        double[,] result = new double[matrixRows, matrixCols];
            for (int i = 0; i < matrixRows; i++)
                for (int y = 0; y < matrixCols; y++)
                {
                    result[i, y] = 0;
                    for (int z = 0; z < 2; z++)
                        result[i, y] += matrix[i, z] * rotateMatrix[z, y];
                }
        return result;
    }
}

