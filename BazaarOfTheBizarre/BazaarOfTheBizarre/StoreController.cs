using System;
using System.Threading;
using System.Collections.Generic;

namespace BazaarOfTheBizarre
{
	public class StoreController
	{
		
		List<Store> _stores = new List<Store>();
		List<Customer> _customers = new List<Customer>();	
		
		Store _currentStore;
		Customer _currentCustomer;
		
		Object _lock = new Object();
		StoreView _view = new StoreView();
		
		int sCount = 0;
		int cCount = 0;
		
		public StoreController(List<Store> stores, List<Customer> customers)
		{
			_stores = stores;
			_customers = customers;
		}
		
		//selve utførelsesmetoden. lager tråde og starter disse. kalt newDay for å gjenspeile en ny dag på markedet
		public void newDay()
		{
			Thread[] itemThreads = new Thread[_stores.Count];
			Thread[] customerThread = new Thread[_customers.Count];
			
			foreach(Store s in _stores)
			{
				foreach(Item it in s.itemsInStock)
				{
					Console.WriteLine(s.name + " -- " + it.name);
				}
			}
			Console.WriteLine("-------------------------------------");
			
			for(int i = 0; i < _stores.Count; i++) {
				Thread t = new Thread(new ThreadStart(startTransaction));
				t.Name = "store"+i;
				itemThreads[i] = t;
			}
			for(int i = 0; i < _stores.Count; i++) {
				itemThreads[i].Start();
			}
			
			for(int i = 0; i < _customers.Count; i++) {
				Thread t = new Thread(new ThreadStart(endTransaction));
				t.Name = "customer"+i;
				customerThread[i] = t;
			}
			for(int i = 0; i < _customers.Count; i++) {
				customerThread[i].Start();
			}
		}
		
		//Metode for å legge ut vare for salg
		public void startTransaction()
		{
			while(checkIfOpen())
			{
				lock(_lock)
				{
					nextStore();
					if(_currentStore.itemForSale == null && _currentStore.isOpen)
					{
						_currentStore.putItemForSale();
						_view.announceItemForSale(_currentStore);
						Thread.Sleep(1000);
					}
				}
			}
		}
		
		//Metode for å utføre kjøp og salg
		public void endTransaction()
		{
			while(checkIfOpen())
			{
				if(_currentStore != null)
				{
					lock(_lock)
					{
						nextCustomer();
						if(_currentCustomer.buyItem(_currentStore))
						{
							_view.announceSale(_currentCustomer, _currentStore);
							_currentStore.itemForSale = null;
							Thread.Sleep(2000);
						} else {
							nextStore();
						}
					}
				}
			}
		}
		
		//Hjelpemetode for å sjekke om det er tomt for items
		bool checkIfOpen() {
			foreach(Store s in _stores)
			{
				if(s.isOpen) return true;
			}
			return false;
		}
		
		//Hjelpemetode for å skifte mellom de som handler
		void nextCustomer()
		{
			if(cCount == _customers.Count)
			{
				cCount = 0;
			}
			_currentCustomer = _customers[cCount];
			cCount++;
		}
		
		//Hjelpemetode for å skifte mellom butikkene
		void nextStore()
		{
			if(sCount == _stores.Count)
			{
				sCount = 0;
			}
			_currentStore = _stores[sCount];
			sCount++;
		}
		
	}
}