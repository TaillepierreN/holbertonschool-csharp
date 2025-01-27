using System;

/// <summary>
/// Class for vector math
/// </summary>
class VectorMath
{
    /// <summary>
    /// Multiply a 2d / 3d vector by a scalar
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="scalar"></param>
    /// <returns></returns>
    public static double[] Multiply(double[] vector, double scalar)
    {
        if (vector.Length < 2 || vector.Length > 3)
            return new double[] { -1 };
        double[] result = new double[vector.Length];

        for (int i = 0; i < vector.Length; i++)
            result[i] = vector[i] * scalar;
        return result;
    }
}

