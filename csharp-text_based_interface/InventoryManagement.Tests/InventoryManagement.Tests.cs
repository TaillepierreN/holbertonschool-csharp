using NUnit.Framework;
using InventoryLibrary;
using System;

namespace InventoryManagement.Tests
{
    public class InventoryManagementTests
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
        private readonly string filePath = Path.Combine("storage", "inventory_manager.json");
        private string? backupContent;

        [SetUp]
        public void SetUp()
        {
            // Backup existing file if it exists
            if (File.Exists(filePath))
                backupContent = File.ReadAllText(filePath);
        }

        [TearDown]
        public void TearDown()
        {
            // Restore original file after test
            if (backupContent != null)
                File.WriteAllText(filePath, backupContent);
            else if (File.Exists(filePath))
                File.Delete(filePath);
        }

        [Test]
        public void New_AddsObjectSuccessfully()
        {
            var storage = new JSONStorage();
            var user = new User("TestUser");

            storage.New(user);

            var key = $"User.{user.id}";
            Assert.That(storage.objects.ContainsKey(key), Is.True);
        }

        [Test]
        public void Save_CreatesFileWithContent()
        {
            var storage = new JSONStorage();
            storage.New(new User("TestUser"));

            storage.Save();

            Assert.That(File.Exists(filePath), Is.True);
            var json = File.ReadAllText(filePath);
            Assert.That(json.Length, Is.GreaterThan(0));
        }

        [Test]
        public void Load_RestoresObjectsCorrectly()
        {
            var storage = new JSONStorage();
            var user = new User("TestUser");
            storage.New(user);
            storage.Save();

            var storage2 = new JSONStorage();
            storage2.Load();

            var key = $"User.{user.id}";
            Assert.That(storage2.objects.ContainsKey(key), Is.True);
        }

        [Test]
        public void GetObject_ReturnsCorrectDeserializedInstance()
        {
            var storage = new JSONStorage();
            var user = new User("DeserializedUser");
            storage.New(user);
            storage.Save();

            var key = $"User.{user.id}";
            var result = storage.GetObject<User>(key);

            Assert.That(result.name, Is.EqualTo("DeserializedUser"));
        }
        [Test]
        public void ItemConstructor_SetsNameCorrectly()
        {
            var item = new Item("Potion");
            Assert.That(item.name, Is.EqualTo("Potion"));
        }

        [Test]
        public void DefaultConstructor_SetsDefaults()
        {
            var item = new Item();
            Assert.That(item.name, Is.EqualTo(""));
            Assert.That(item.description, Is.EqualTo(""));
            Assert.That(item.price, Is.EqualTo(0));
            Assert.That(item.tags, Is.Not.Null);
        }

        [Test]
        public void ItemConstructor_ThrowsOnEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new Item(""));
        }

        [Test]
        public void ItemConstructor_ThrowsOnNullName()
        {
            Assert.Throws<ArgumentException>(() => new Item(null));
        }

        [Test]
        public void Price_CanBeSetAndRounded()
        {
            var item = new Item("Elixir");
            item.price = 19.567f;
            Assert.That(item.price, Is.EqualTo(19.567f));
        }
    }
}
