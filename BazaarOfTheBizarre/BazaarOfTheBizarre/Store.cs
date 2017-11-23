using System;
using System.IO;
using System.Net;

namespace BazaarOfTheBizarre
{
	interface StoreInterface
	{
		void newDay();
		Item[] itemFactory();
		void sellItems(Item i, Customer c);
		
	}
	/// <summary>
	/// Description of Store.
	/// </summary>
	public class Store :StoreInterface
	{
		public string name {get; private set;}
		public Store(string name, Customer[] customers)
		{
			this.name = name;
		}
		
		public void newDay()
		{
			bool dayOver = false;
			Item[] items = itemFactory();
			while(!dayOver) {
				
			}
			//generere items
			//legge ut for salg
			//selge
			// X ??? så det passer i console
		}
		
		public Item[] itemFactory() {
			string path = Directory.GetCurrentDirectory();
			//string[] allLines = File.ReadAllLines(path);
			Console.WriteLine("" + path);
			return null;
		}
		public void sellItems(Item i, Customer c) {
			
		}
	}
}
