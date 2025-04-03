using NUnit.Framework;
using InventoryLibrary;
using System;

namespace InventoryManagement.Tests
{
    public class UserTests
    {
        [Test]
        public void Constructor_SetsNameCorrectly()
        {
            var user = new User("Nico");
            Assert.That(user.name, Is.EqualTo("Nico"));
        }

        [Test]
        public void Constructor_ThrowsOnEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new User(""));
        }

        [Test]
        public void Constructor_ThrowsOnNullName()
        {
            Assert.Throws<ArgumentException>(() => new User(null));
        }
    }
}
