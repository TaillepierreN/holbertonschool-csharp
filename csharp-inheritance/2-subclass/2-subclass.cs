using System;

/// <summary>
/// Class to check if a type is a subclass of another type.
/// </summary>
class Obj
{
    /// <summary>
    /// Check if a type is a subclass of another type.
    /// </summary>
    /// <param name="derivedType"> type</param>
    /// <param name="baseType">type</param>
    /// <returns>bool</returns>
    public static bool IsOnlyASubclass(Type derivedType, Type baseType)
    {
        return baseType.IsAssignableFrom(derivedType) && derivedType != baseType;
    }
}

