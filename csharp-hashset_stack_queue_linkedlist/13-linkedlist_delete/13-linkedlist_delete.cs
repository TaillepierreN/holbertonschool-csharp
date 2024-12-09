using System;
using System.Collections.Generic;

class LList
{
    public static void Delete(LinkedList<int> myLList, int index)
    {
        LinkedListNode<int> headerLink = myLList.First;
        int i = 0;

        while (headerLink != null)
        {
            if (i == index)
            {
                myLList.Remove(headerLink);
                break;
            }
            i++;
            headerLink = headerLink.Next;
        }
    }
}