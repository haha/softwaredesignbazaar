using System;
using System.Collections.Generic;
using System.IO;

namespace BazaarOfTheBizarre
{
	interface StoreInterface
	{
		void newDay();
		List<Item> itemFactory();
		Item checkStoreItems(List<Item> list);
		
	}
	/// <summary>
	/// Description of Store..
	/// </summary>
	public class Store :StoreInterface
	{
		public string name {get; private set;}
		public List<Customer> customers;
		public int itemcount {get; private set;}
		
		public Store(string name, List<Customer> customers)
		{
			this.customers = new List<Customer>();
			this.name = name;
			this.customers = customers;
			this.itemcount = 3;
		}
		
		public void newDay()
		{
			bool dayOver = false;
			List<Item> items = itemFactory();
			Item i;
			while(!dayOver) {
				if(Console.KeyAvailable)
				{
					if(Console.ReadKey(true).Key == ConsoleKey.A)
					{
						i = checkStoreItems(items);
						items = itemFactory();
					} else if(Console.ReadKey(true).Key == ConsoleKey.B)
					{
						dayOver = true;
					}
				}
			}
			i = checkStoreItems(items);
		}
		
		public List<Item> itemFactory() {
			List<Item> itemList = new List<Item>();
			string path = AppDomain.CurrentDomain.BaseDirectory;
			Random r = new Random();
			if(path.EndsWith("\\bin\\Debug\\"))
			{
				path = path.Replace("\\bin\\Debug", "");
			}
			path = path + "ItemNames.txt";
			string[] allLines = File.ReadAllLines(path);
			for(int i = 0; i < itemcount; i++) 
			{
				itemList.Add(new Item(allLines[r.Next(allLines.Length)]));
			}
			return itemList;
		}
		
		public Item checkStoreItems(List<Item> list) {
			foreach (Item i in list)
			{
				Console.WriteLine(i.name);
				
			}
			return null;
		}
	}
}
