using NUnit.Framework;
using System.IO;
using InventoryLibrary;

namespace InventoryManagement.Tests
{
    [TestFixture]
    public class JSONStorageTests
    {

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
    }
}
