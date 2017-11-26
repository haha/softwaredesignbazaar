using System;
using NUnit.Framework;

namespace BazaarOfTheBizarre
{
	[TestFixture]
	public class StoreTest
	{
		Store testBazaar = new Store("test", 3);
		
		//tester generering av varer
		[Test]
		public void testingItemFactory()
		{
			testBazaar.restock(3);
			Assert.AreEqual(testBazaar.itemsInStock.Count, testBazaar.itemCountInStock);
		}
	}
}