using System;

/// <summary>
/// Class for shape
/// </summary>
class Shape
{
    /// <summary>
    /// Calculate the area of a shape.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public virtual int Area()
    {
        throw new NotImplementedException("Area() is not implemented");
    }
}
