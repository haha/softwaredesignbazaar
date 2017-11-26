using System;

namespace BazaarOfTheBizarre
{
	public class StoreView
	{
		
		//Annonserer ny vare for salg
		public void announceItemForSale(Store s) 
		{
			Console.WriteLine(s.name + " puts " + s.itemForSale.name + " up for sale");
		}
		
		//Annonserer at en vare er solgt
		public void announceSale(Customer c, Store s)
		{
			string sale = c.name + " bought " + s.name + "'s " + s.itemForSale.name;
			Console.CursorLeft = Console.BufferWidth - sale.Length;
			Console.Write(sale);
		}
	}
}
