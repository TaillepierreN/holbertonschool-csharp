using System;
using System.Collections.Generic;

namespace InventoryLibrary
{
    public class Item : BaseClass
    {
        public string name { get; set; }

        public string description { get; set; }

        public float price { get; set; }

        public List<string> tags { get; set; }

        public Item()
        {
            name = "";
            description = "";
            price = 0;
            tags = new List<string>();
        }

        public Item(string name) : this()
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));

            this.name = name;
        }
    }
}
