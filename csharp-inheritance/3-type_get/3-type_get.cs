﻿using System;
using System.Reflection;

class Obj
{
    public static void Print(object myObj)
    {
        TypeInfo type = myObj.GetType().GetTypeInfo();

        Console.WriteLine(type.Name + " Properties:");
        foreach (PropertyInfo prop in type.DeclaredProperties)
            Console.WriteLine(prop.Name);

        Console.WriteLine(type.Name + " Methods:");
        foreach (MethodInfo method in type.DeclaredMethods)
            if (method.DeclaringType == type.AsType() 
                && !method.IsSpecialName
                && !method.Name.StartsWith("System") 
                && !method.Name.StartsWith("get_") 
                && !method.Name.StartsWith("set_")
                Console.WriteLine(method.Name);
    }
}

