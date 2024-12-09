using System;
using System.Collections.Generic;

class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        System.Console.WriteLine(string.Format("Number of items: {0}", aStack.Count));

        System.Console.WriteLine(string.Format("{0}",aStack.Count == 0 ? "Stack is empty" : "Top item: " + aStack.Peek()));

        System.Console.WriteLine(string.Format("Stack contains \"{0}\": {1}", search, aStack.Contains(search)? "True" : "False"));

        if (aStack.Contains(search))
        {
            while (aStack.Contains(search))
                aStack.Pop();
        }

        aStack.Push(newItem);

        return aStack;
    }
}

