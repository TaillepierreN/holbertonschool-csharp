using System;
using System.Collections.Generic;

class LList
{
    public static int GetNode(LinkedList<int> myLList, int n)
    {
        int currentNode = 0;

        foreach (int node in myLList)
        {
            if (currentNode == n)
                return node;
            currentNode++;
        }
        return 0;
    }
}