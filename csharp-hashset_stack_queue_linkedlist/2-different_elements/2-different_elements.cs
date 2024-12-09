using System;
using System.Collections.Generic;

class List
{
    public static List<int> DifferentElements(List<int> list1, List<int> list2)
    {
        HashSet<int> firstList = new HashSet<int>(list1);
        firstList.SymmetricExceptWith(list2);
        List<int> commonList = new List<int>(firstList);
        commonList.Sort();
        return commonList;
    }
}

