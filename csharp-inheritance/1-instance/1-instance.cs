using System;

/// <summary>
/// Class to check if an object is instance of array.
/// </summary>
class Obj
{
    /// <summary>
    /// Check if an object is instance of array.
    /// </summary>
    /// <param name="obj">object to check</param>
    /// <returns>bool</returns>
    public static bool IsInstanceOfArray(object obj)
    {
        return obj typeof(Array).IsInstanceOf(obj);
    }
}

