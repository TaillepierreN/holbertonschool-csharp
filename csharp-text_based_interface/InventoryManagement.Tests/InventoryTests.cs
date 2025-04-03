using NUnit.Framework;
using InventoryLibrary;
using System;

namespace InventoryManagement.Tests
{
    public class InventoryTests
    {
        [Test]
        public void Constructor_SetsPropertiesCorrectly()
        {
            var inventory = new Inventory("user123", "item456", 3);
            Assert.That(inventory.user_id, Is.EqualTo("user123"));
            Assert.That(inventory.item_id, Is.EqualTo("item456"));
            Assert.That(inventory.quantity, Is.EqualTo(3));
        }

        [Test]
        public void Quantity_CannotBeNegative()
        {
            var inventory = new Inventory("user", "item");
            Assert.Throws<ArgumentException>(() => inventory.quantity = -1);
        }

        [Test]
        public void DefaultQuantity_IsOne()
        {
            var inventory = new Inventory("user1", "item1");
            Assert.That(inventory.quantity, Is.EqualTo(1));
        }
    }
}
