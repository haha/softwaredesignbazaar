using System;
using System.Collections.Generic;

namespace BazaarOfTheBizarre
{
	interface StoreInterface
	{
		void putItemForSale();
		void restock(int itemCount);
	}
	public class Store :StoreInterface
	{
		public string name {get; private set;}
		public List<Item> itemsInStock {get; private set;}
		public Item itemForSale {get; set;}
		
		public int itemCountInStock;
		
		public bool isOpen;
		ItemFactory _factory = new ItemFactory();
		
		public Store(string name, int itemCount)
		{
			this.name = name;
			itemForSale = null;
			restock(itemCount);
		}
		//Legger vare fram for salg og sjekker om det er tomt
		public void putItemForSale()
		{
			itemForSale = itemsInStock[itemCountInStock-1];
			itemsInStock.Remove(itemForSale);
			itemCountInStock--;
			if(itemCountInStock == 0)
			{
				isOpen = false;
			}
		}
		//Fyller opp varelageret
		public void restock(int itemCount)
		{
			itemsInStock = _factory.generateItems(itemCount);
			itemCountInStock = itemCount;
			isOpen = true;
		}
	}
}
