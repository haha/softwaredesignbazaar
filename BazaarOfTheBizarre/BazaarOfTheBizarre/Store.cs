using System;
using System.Collections.Generic;

namespace BazaarOfTheBizarre
{
	interface StoreInterface
	{
		Item putItemForSale();
		void sellItem(Item i);
		void restock();
	}
	/// <summary>
	/// Description of Store..
	/// </summary>
	public class Store :StoreInterface
	{
		public string name {get; private set;}
		public List<Item> itemsInStock {get; private set;}
		public int itemCount = 3;
		public int itemCountInStock;
		private ItemFactory factory = new ItemFactory();
		private Object _lock = new Object();
		
		public Store(string name, List<Customer> customers)
		{
			this.name = name;
			restock();
		}
		
		public Item putItemForSale()
		{
			Item i = null;
			if(itemCountInStock > 0)
			{
				i = itemsInStock[itemCountInStock-1];
			}
			return i;
		}
		
		public void sellItem(Item i)
		{
			itemsInStock.Remove(i);
			itemCountInStock--;
		}
		
		public bool findItem(Item i)
		{
			foreach(Item it in itemsInStock)
			{
				if(it.Equals(i))
				{
					return true;
				}
			}
			return false;
		}
		
		public void restock()
		{
			itemsInStock = factory.generateItems(itemCount);
			itemCountInStock = itemCount;
		}
	}
}
