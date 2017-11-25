using System;
using System.Threading;
using System.Collections.Generic;

namespace BazaarOfTheBizarre
{
	/// <summary>
	/// Description of StoreController.
	/// </summary>
	public class StoreController
	{
		private List<Store> stores = new List<Store>();
		private StoreView view = new StoreView();
		private List<Customer> customers = new List<Customer>();
		
		public StoreController(List<Store> stores)
		{
			this.stores = stores;
			customers.Add(new Customer("Per"));
			customers.Add(new Customer("Paul"));
			customers.Add(new Customer("Espen"));
		}
		
		public void newDay()
		{
			foreach(Store s in stores)
			{
				bool dayOver = false;
				do {
					if(s.itemCountInStock <= 0)
					{
						Console.WriteLine("\nPress A for new day of bazaaring or B to exit\n"); //LEGG I VIEW
						if(Console.ReadKey(true).Key == ConsoleKey.A)
						{
							s.restock();
						} else if(Console.ReadKey(true).Key == ConsoleKey.B)
						{
							dayOver = true;
						}
					} else {
						Thread[] threads = new Thread[s.itemCount];
						
						for(int j = 0; j < s.itemCount; j++)
						{
							Thread t = new Thread(new ThreadStart(doTransaction));
							threads[j] = t;
						}
						
						for(int j = 0; j < s.itemCount; j++) {
							threads[j].Start();
						}
						
						
					}
				} while (!dayOver);
			}
		}
		public void doTransaction(Store s)
		{
			Item i = s.putItemForSale();
			view.announceItemForSale(s, i);
			foreach(Customer c in customers) {
				c.buyItem(i);
				view.announceSale(c, s, i);
			}
		}
	}
}
