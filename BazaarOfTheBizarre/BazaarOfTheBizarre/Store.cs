using System;

namespace BazaarOfTheBizarre
{
	interface StoreInterface
	{
		void newDay();
		Item[] generateItems();
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
			//generere items
			//legge ut for salg
			//selge
			// X ??? så det passer i console
		}
		
		private Item[] generateItems();
		private void sellItems(Item i, Customer c);
	}
}
