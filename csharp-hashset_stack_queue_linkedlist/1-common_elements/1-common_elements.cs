using System;
using System.Collections.Generic;

class List
{
    public static List<int> CommonElements(List<int> list1, List<int> list2)
    {
        HashSet<int> common = new HashSet<int>(list1);
        common.IntersectWith(list2);
        List<int> commonList = new List<int>(common);
        return commonList;
    }
}

