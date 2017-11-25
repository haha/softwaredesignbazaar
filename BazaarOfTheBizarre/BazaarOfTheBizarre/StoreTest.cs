using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace BazaarOfTheBizarre
{
	[TestFixture]
	public class StoreTest
	{
		Store testBazaar = new Store("test", null);
		
		[Test]
		public void testingItemFactory()
		{
			testBazaar.restock();
			Assert.AreEqual(testBazaar.itemsInStock.Count, testBazaar.itemCount);
		}
	}
}