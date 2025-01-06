using System;
using System.Text.RegularExpressions;

namespace Text
{
    /// <summary>
    /// Str class
    /// </summary>
    public class Str
    {
        /// <summary>
        /// check if palindrome
        /// </summary>
        /// <param name="s">string to check</param>
        /// <returns>bool True if is palindrome</returns>
        public static bool IsPalindrome(string s)
        {
            if (s == null)
                return false;
            if (s == "")
                return true;
            
            string cleanedString = Regex.Replace(s, @"[^0-9a-zA-Z]+", "").ToLower();
            int indexStart = 0;
            int indexEnd = cleanedString.Length - 1;


            while (indexStart < indexEnd)
            {
                if (cleanedString[indexStart] != cleanedString[indexEnd])
                    return false;
                indexStart++;
                indexEnd--;
            }
            return true;
        }
    }
}
