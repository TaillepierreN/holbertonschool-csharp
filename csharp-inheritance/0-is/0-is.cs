using System;

/// <summary>
/// Class to check if an object is of type int.
/// </summary>
    class Obj
    {
        /// <summary>
        /// Check if an object is of type int.
        /// </summary>
        /// <param name="obj">object to check</param>
        /// <returns>True if in,otherwise false</returns>
        public static bool IsOfTypeInt(object obj)
        {
            return obj is int;
        }
    }

