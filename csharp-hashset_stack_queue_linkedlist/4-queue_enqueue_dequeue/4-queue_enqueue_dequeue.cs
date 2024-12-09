using System;
using System.Collections.Generic;

public class MyQueue
{
    public static Queue<string> Info(Queue<string> aQueue, string newItem, string search)
    {
        System.Console.WriteLine(string.Format("Number of items: {0}", aQueue.Count));

        System.Console.WriteLine(string.Format("{0}", aQueue.Count == 0 ? "Queue is empty" : "First item: " + aQueue.Peek()));
        
        aQueue.Enqueue(newItem);

        System.Console.WriteLine(string.Format("Queue contains \"{0}\": {1}", search, aQueue.Contains(search) ? "True" : "False"));

        if (aQueue.Contains(search))
        {
            while (aQueue.Contains(search))
                aQueue.Dequeue();
        }

        return aQueue;
    }
}