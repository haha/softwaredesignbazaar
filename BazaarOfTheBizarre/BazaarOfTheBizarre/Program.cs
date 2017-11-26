using System;
using System.Collections.Generic;

namespace BazaarOfTheBizarre
{
	public static class Program
	{
		//Main metoden. Navn på varer kan være identiske, men er selv fortsatt unike
		public static void Main(string [] args)
		{	
			List<Store> stores = new List<Store>();
			stores.Add(new Store("Balthazar", 3));
			stores.Add(new Store("Baba Yoga", 3));
			
			List<Customer> customers = new List<Customer>();
			customers.Add(new Customer("Fafhrd"));
			customers.Add(new Customer("Santom"));
			customers.Add(new Customer("Gray Mouser"));
			
			StoreController sc = new StoreController(stores, customers);
			sc.newDay();
			
			Console.ReadKey();
		}
	}
}
