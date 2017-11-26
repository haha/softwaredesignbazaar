using System;
using System.Collections.Generic;

namespace BazaarOfTheBizarre
{
	/// <summary>
	/// Description of Program.
	/// </summary>
	public static class Program
	{
		public static void Main(string [] args)
		{	
			List<Store> stores = new List<Store>();
			stores.Add(new Store("Bazaar of the Bizarre", null));
			stores.Add(new Store("Super store", null));
			
			StoreController sc = new StoreController(stores);
			sc.newDay();
			
			Console.ReadKey();
		}
	}
}
