using System;

/// <summary>
/// Class for vector math
/// </summary>
class VectorMath
{
    /// <summary>
    /// Calculate the dot product of two vectors
    /// </summary>
    /// <param name="vector1"></param>
    /// <param name="vector2"></param>
    /// <returns></returns>
    public static double DotProduct(double[] vector1, double[] vector2)
    {
        if (vector1.Length != vector2.Length || vector1.Length < 2 || vector1.Length > 3
        || vector2.Length < 2 || vector2.Length > 3)
            return -1;
        
        double result = 0;
        for (int i = 0; i < vector1.Length; i++)
            result += vector1[i] * vector2[i];
        return result;
    }
}

