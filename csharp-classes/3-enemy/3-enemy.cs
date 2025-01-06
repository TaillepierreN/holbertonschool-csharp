using System;

namespace Enemies
{
    /// <summary> Represents a zombie.</summary>
    public class Zombie
    {
        private int health;

        /// <summary> Initializes a new instance of the zombie class.</summary>
        public Zombie()
        {
            health = 0;
        }

        /// <summary> Initializes a new instance of the zombie class with a given health value.</summary>
        public Zombie(int value)
        {
            if (value < 0) throw new ArgumentException("Health must be greater than or equal to 0");
            health = value;
        }

        /// <summary> Gets the health of the zombie. </summary>
        /// <returns>int health</returns>
        public int GetHealth()
        {
            return health;
        }
    }
}
