using System;

namespace InventoryLibrary
{
    public class User : BaseClass
    {
        public string name { get; set; }

        public User() { }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));

            this.name = name;
        }
    }

}