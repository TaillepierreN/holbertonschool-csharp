using System;
using System.Collections.Generic;

class LList
{
    public static LinkedListNode<int> Insert(LinkedList<int> myLList, int n)
    {
        LinkedListNode<int> newNode = new LinkedListNode<int>(n);
        LinkedListNode<int> currentNode = myLList.First;

        if (currentNode == null || currentNode.Value > n)
        {
            myLList.AddFirst(newNode);
            return newNode;
        }

        while (currentNode.Next != null && currentNode.Next.Value < n)
            currentNode = currentNode.Next;

        myLList.AddAfter(currentNode, newNode);
        return newNode;
    }
}