using System;

/// <summary>
/// Class for vector math
/// </summary>
class VectorMath
{
    /// <summary>
    /// Calculate the magnitude of a 2d or 3d vector.
    /// </summary>
    /// <param name="vector">double[] vector</param>
    /// <returns>double</returns>
    public static double Magnitude(double[] vector)
    {
        if (vector.Length < 2 || vector.Length > 3)
            return -1;
        double sum = 0;
        foreach (double vectron in vector)
            sum += vectron * vectron;
        
        return Math.Round(Math.Sqrt(sum), 2);
    }
}

