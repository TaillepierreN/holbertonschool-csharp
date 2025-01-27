// using System;

// /// <summary>
// /// class for matrix math
// /// </summary>
// class MatrixMath
// {
//     /// <summary>
//     /// rotate a 2d matrix given an angle in radians
//     /// </summary>
//     /// <param name="matrix"></param>
//     /// <param name="angle"></param>
//     /// <returns></returns>
//     public static double[,] Rotate2D(double[,] matrix, double angle)
//     {
//         int matrixRows = matrix.GetLength(0);
//         int matrixCols = matrix.GetLength(1);

//         if (matrixRows != matrixCols || matrixRows < 2)
//             return new double[,] { { -1 } };

//         double cosTheta = Math.Cos(angle);
//         double sinTheta = Math.Sin(angle);

//         double[,] result = new double[matrixRows, matrixCols];

//         for (int i = 0; i < matrixRows; i++)
//         {
//             for (int j = 0; j < matrixCols; j++)
//             {
//                 int newX = (int)Math.Round(cosTheta * (j - matrixCols / 2) - sinTheta * (i - matrixRows / 2) + matrixCols / 2);
//                 int newY = (int)Math.Round(sinTheta * (j - matrixCols / 2) + cosTheta * (i - matrixRows / 2) + matrixRows / 2);

//                 if (newX >= 0 && newX < matrixCols && newY >= 0 && newY < matrixRows)
//                 {
//                     result[newY, newX] = matrix[i, j];
//                 }
//             }
//         }
//         return result;
//     }
// }
