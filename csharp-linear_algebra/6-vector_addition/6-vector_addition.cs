using System;

/// <summary>
/// Class for vector math
/// </summary>
class VectorMath
{
    /// <summary>
    /// Add two 2d / 3d vectors
    /// </summary>
    /// <param name="vector1"></param>
    /// <param name="vector2"></param>
    /// <returns></returns>
    public static double[] Add(double[] vector1, double[] vector2)
    {
        if (vector1.Length != vector2.Length || vector1.Length < 2 || vector1.Length > 3
        || vector2.Length < 2 || vector2.Length > 3)
            return new double[] { -1 };

        double[] result = new double[vector1.Length];
        for (int i = 0; i < vector1.Length; i++)
            result[i] = vector1[i] + vector2[i];
        return result;
    }
}

