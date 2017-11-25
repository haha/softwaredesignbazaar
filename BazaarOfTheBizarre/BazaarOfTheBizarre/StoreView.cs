using System;

namespace BazaarOfTheBizarre
{
	/// <summary>
	/// Description of StoreView.
	/// </summary>
	public class StoreView
	{
		public void announceItemForSale(Store s, Item i) 
		{
			Console.WriteLine(s.name + " puts " + i.name + " up for sale");
		}
		
		public void announceSale(Customer c, Store s, Item i)
		{
			string sale = c.name + " bought " + s.name + "'s " + i.name;
			Console.CursorLeft = Console.BufferWidth - sale.Length;
			Console.Write(sale);
		}
	}
}
