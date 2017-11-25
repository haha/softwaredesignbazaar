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
			StoreController s = new StoreController(stores);
			s.newDay();
			
			Console.ReadKey();
		}
	}
}
