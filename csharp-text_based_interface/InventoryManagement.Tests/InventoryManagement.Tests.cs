using System;
using Xunit;
using InventoryLibrary;
using System.Collections.Generic;

namespace InventoryManagement.Tests
{
    public class BaseClassTests
    {
        [Fact]
        public void BaseClass_InitializesFields()
        {
            var obj = new BaseClass();
            Assert.False(string.IsNullOrEmpty(obj.id));
            Assert.True((DateTime.Now - obj.date_created).TotalSeconds < 2);
            Assert.True((DateTime.Now - obj.date_updated).TotalSeconds < 2);
        }
    }

    public class ItemTests
    {
        [Fact]
        public void Item_CreatesWithValidName()
        {
            var item = new Item("Laptop");
            Assert.Equal("Laptop", item.name);
            Assert.Equal("", item.description);
            Assert.Equal(0.0f, item.price);
            Assert.IsType<List<string>>(item.tags);
        }

        [Fact]
        public void Item_ThrowsOnNullName()
        {
            Assert.Throws<ArgumentException>(() => new Item(null));
        }
    }

    public class UserTests
    {
        [Fact]
        public void User_CreatesWithValidName()
        {
            var user = new User("Alice");
            Assert.Equal("Alice", user.name);
        }

        [Fact]
        public void User_ThrowsOnEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new User(""));
        }
    }

    public class InventoryTests
    {
        [Fact]
        public void Inventory_CreatesWithValidValues()
        {
            var inv = new Inventory("user123", "item456", 2);
            Assert.Equal("user123", inv.user_id);
            Assert.Equal("item456", inv.item_id);
            Assert.Equal(2, inv.quantity);
        }

        [Fact]
        public void Inventory_ThrowsOnNegativeQuantity()
        {
            Assert.Throws<ArgumentException>(() => new Inventory("user123", "item456", -1));
        }

        [Fact]
        public void Inventory_ThrowsOnMissingIds()
        {
            Assert.Throws<ArgumentException>(() => new Inventory(null, "item456"));
            Assert.Throws<ArgumentException>(() => new Inventory("user123", null));
        }
    }
}