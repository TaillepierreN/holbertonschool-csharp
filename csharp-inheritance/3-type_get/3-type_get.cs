using System;
using System.Reflection;

/// <summary>
/// Class to print the properties and methods of an object.
/// </summary>
class Obj
{
    /// <summary>
    /// Print the properties and methods of an object.
    /// </summary>
    /// <param name="myObj"></param>
    public static void Print(object myObj)
    {
        TypeInfo type = myObj.GetType().GetTypeInfo();

        Console.WriteLine(type.Name + " Properties:");
        foreach (PropertyInfo prop in type.GetProperties())
            Console.WriteLine(prop.Name);

        Console.WriteLine(type.Name + " Methods:");
        foreach (MethodInfo method in type.GetMethods())
            Console.WriteLine(method.Name);
    }
}

