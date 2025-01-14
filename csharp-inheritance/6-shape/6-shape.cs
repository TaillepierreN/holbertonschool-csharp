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

/// <summary>
/// Class for rectangle
/// </summary>
class Rectangle : Shape
{
    private int width;
    private int height;
    public int Width
    {
        get => width;
        set
        {
            if (value < 0) throw new ArgumentException("Width must be greater than or equal to 0");
            width = value;
        }
    }
    public int Height
    {
        get => height;
        set
        {
            if (value < 0) throw new ArgumentException("Height must be greater than or equal to 0");
            height = value;
        }
    }
}