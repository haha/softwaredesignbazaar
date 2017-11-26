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
		private Item _currentItem = null;
		private Store _currentStore = null;
		private Object _lock = new Object();
		private Object _lock2 = new Object();
		
		int sCount = 0;
		int cCount = 0;
		
		public StoreController(List<Store> stores)
		{
			this.stores = stores;
			customers.Add(new Customer("Per"));
			customers.Add(new Customer("Paul"));
			customers.Add(new Customer("Espen"));
		}
		
		public void newDay()
		{
			_currentStore = stores[sCount];
			Thread[] itemThreads = new Thread[stores.Count];
			Thread[] customerThread = new Thread[customers.Count];
			foreach(Store s in stores)
			{
				foreach(Item it in s.itemsInStock)
				{
					Console.WriteLine(s.name + " -- " + it.name);
				}
			}
			Console.WriteLine("-------------------------------------");
			for(int i = 0; i < stores.Count; i++) {
				Thread t = new Thread(new ThreadStart(startTransaction));
				itemThreads[i] = t;
			}
			for(int i = 0; i < stores.Count; i++) {
				itemThreads[i].Start();
			}
			
			for(int i = 0; i < customers.Count; i++) {
				Thread t = new Thread(new ThreadStart(endTransaction));
				customerThread[i] = t;
			}
			for(int i = 0; i < customers.Count; i++) {
				customerThread[i].Start();
			}
		}
		
		public void startTransaction()
		{
			while(_currentStore.itemCountInStock > 0)
			{
				lock(_lock)
				{
					if(sCount == stores.Count)
					{
						sCount = 0;
					}
					_currentStore = stores[sCount];
					sCount++;
					
					if(_currentItem == null && _currentStore.itemCountInStock > 0)
					{
						_currentItem = _currentStore.putItemForSale();
						view.announceItemForSale(_currentStore, _currentItem);
						Thread.Sleep(1000);
					}
				}
			}
			
		}
		public void endTransaction()
		{
			while(_currentStore.itemCountInStock >= 0)
			{
				if(cCount == customers.Count)
				{
					cCount = 0;
				}
				Customer c = customers[cCount];
				cCount++;
				lock(_lock)
				{
					
					
					if(c.buyItem(_currentItem, _currentStore))
					{
						view.announceSale(c, _currentStore, _currentItem);
						_currentItem = null;
						Thread.Sleep(1000);
					} else {
						//Console.WriteLine("Tomt");
						Thread.Sleep(200);
					}
				}
			}
			
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
