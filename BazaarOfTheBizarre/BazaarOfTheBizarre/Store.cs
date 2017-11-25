using System;
using System.Collections.Generic;

namespace BazaarOfTheBizarre
{
	interface StoreInterface
	{
		Item putItemForSale();
		void restock();
	}
	/// <summary>
	/// Description of Store..
	/// </summary>
	public class Store :StoreInterface
	{
		public string name {get; private set;}
		public List<Item> itemsInStock {get; private set;}
		//public int itemCount {get; private set;}
		public int itemCount = 3;
		public int itemCountInStock;
		private ItemFactory factory = new ItemFactory();
		
		public Store(string name, List<Customer> customers)
		{
			this.name = name;
			restock();
			//this.itemcount = 3;
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
		
		public void sellItem()
		{
			itemsInStock.Remove(itemsInStock[itemCountInStock-1]);
			itemCountInStock--;
		}
		
		public void restock()
		{
			itemsInStock = factory.generateItems(itemCount);
			itemCountInStock = itemCount;
		}
	}
}
