using NUnit.Framework;
using InventoryLibrary;
using System;

namespace InventoryManagement.Tests
{
    public class BaseClassTests
    {
        class TestClass : BaseClass { }

        [Test]
        public void Constructor_SetsIdAndDates()
        {
            var obj = new TestClass();
            Assert.That(obj.id, Is.Not.Null.And.Not.Empty);
            Assert.That(obj.date_created, Is.EqualTo(obj.date_updated).Within(TimeSpan.FromSeconds(1)));
        }

        [Test]
        public void UpdatingDateUpdated_Works()
        {
            var obj = new TestClass();
            var original = obj.date_updated;
            obj.date_updated = obj.date_updated.AddMinutes(1);
            Assert.That(obj.date_updated, Is.Not.EqualTo(original));
        }
    }
}
