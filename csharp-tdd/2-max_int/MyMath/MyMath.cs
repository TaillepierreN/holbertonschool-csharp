using System;
using System.Collections.Generic;

namespace MyMath
{
    /// <summary>
    /// Operations class
    /// </summary>
    public class Operations
    {
        /// <summary> find max integer in a list </summary>
        public static int Max(List<int> nums)
        {
            if (nums == null || nums.Count <= 0)
                return 0;
            
            int max = nums[0];
            foreach (int num in nums)
                if (num > max) max = num;
            return max;
        }
    }
}
