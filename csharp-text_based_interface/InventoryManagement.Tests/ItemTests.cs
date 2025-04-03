using NUnit.Framework;
using InventoryLibrary;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Tests
{
	public class ItemTests
	{
		[Test]
		public void Constructor_SetsNameCorrectly()
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
		public void Constructor_ThrowsOnEmptyName()
		{
			Assert.Throws<ArgumentException>(() => new Item(""));
		}

		[Test]
		public void Constructor_ThrowsOnNullName()
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