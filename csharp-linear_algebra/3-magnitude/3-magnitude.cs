using System;

class VectorMath
{
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

