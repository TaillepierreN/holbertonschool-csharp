using System;
using System.Collections.Generic;

class LList
{
    public static int Length(LinkedList<int> myLList)
    {
        int length = 0;
        foreach (int i in myLList)
            length ++;

        return length;
    }
}

