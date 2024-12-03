using System;
using System.Collections.Generic;

    class List
    {
        public static List<bool> DivisibleBy2(List<int> myList)
        {
            List<bool> list = new List<bool>();

            if (myList == null || myList.Count == 0)
                return null;
            
            foreach (int nbr in myList)
            {
                if (nbr % 2 == 0)
                    list.Add(true);
                else
                    list.Add(false);
            }
            return list;
        }
    }
