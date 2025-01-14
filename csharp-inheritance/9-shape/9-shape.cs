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
/// <summary>
/// Calculate the area of a rectangle.
/// </summary>
/// <returns></returns>
    public new int Area()
    {
        return width * height;
    }

/// <summary>
/// Return a string representation of the rectangle.
/// </summary>
/// <returns></returns>
    public override string ToString()
    {
        return $"[Rectangle] {width} / {height}";
    }
}

/// <summary>
/// Class for square
/// </summary>
class Square : Rectangle
{
    private int size;
    public int Size
    {
        get => size;
        set
        {
            if (value < 0) throw new ArgumentException("Size must be greater than or equal to 0");
            size = value;
            Height = value;
            Width = value;
        }
    }

    public override string ToString()
    {
        return $"[Square] {size} / {size}";
    }
}