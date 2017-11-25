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
		private Item _currentItem = new Item("");
		private Store _currentStore = new Store("", null);
		private Object _lock = new Object();
		
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
				Thread[] itemThreads = new Thread[s.itemCount];
				Thread[] customerThread = new Thread[customers.Count];
				_currentStore = s;
				foreach(Item i in _currentStore.itemsInStock)
				{
					Console.WriteLine(i.name);
				}
				Console.WriteLine("--------------------------");
				for(int i = 0; i < s.itemCount; i++) {
					Thread t = new Thread(new ThreadStart(startTransaction));
					itemThreads[i] = t;
				}
				for(int i = 0; i < s.itemCount; i++) {
					itemThreads[i].Start();
				}
				for(int i = 0; i < s.itemCount; i++) {
					Thread t = new Thread(new ThreadStart(endTransaction));
					customerThread[i] = t;
				}
				for(int i = 0; i < s.itemCount; i++) {
					customerThread[i].Start();
				}
				
			}
		}
		
		public void startTransaction()
		{
			_currentItem = _currentStore.putItemForSale();
			view.announceItemForSale(_currentStore, _currentItem);
			
		}
		public void endTransaction()
		{
			Random r = new Random();
			Customer c = customers[r.Next(customers.Count-1)];
			c.buyItem(_currentItem, _currentStore);
			view.announceSale(c, _currentStore, _currentItem);
			Console.WriteLine(_currentStore.itemCountInStock);
			
		}
	}
}

//				bool dayOver = false;
//				do {
//
//	if(s.itemCountInStock <= 0)
//					{
//						Console.WriteLine("\nPress A for new day of bazaaring or B to exit\n"); //LEGG I VIEW
//						if(Console.ReadKey(true).Key == ConsoleKey.A)
////						{
////							s.restock();
////						} else if(Console.ReadKey(true).Key == ConsoleKey.B)
////						{
////							dayOver = true;
////						}
//					} else {
//
////						Thread[] threads = new Thread[s.itemCount];
////						for(int j = 0; j < s.itemCount; j++)
////						{
////							Thread t = new Thread(new ThreadStart());
////							threads[j] = t;
////						}
////
////						for(int j = 0; j < s.itemCount; j++) {
////							threads[j].Start();
////						}
//
//
//						Item i = s.putItemForSale();
//						view.announceItemForSale(s, i);
//
//
//
//						foreach(Customer c in customers) {
////							Thread t = new Thread(new ParameterizedThreadStart(c.buyItem));
////							t.Start();
//							if(c.buyItem(i, s))
//							{
//								view.announceSale(c, s, i);
//							}
//						}
//
//
//					}
//				} while (!dayOver);
