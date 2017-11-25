using System;
using System.Collections.Generic;

namespace BazaarOfTheBizarre
{
	interface CustomerInterface
	{
		bool buyItem(Item i, Store s);
	}
	
	/// <summary>
	/// Description of Customer.
	/// </summary>
	public class Customer : CustomerInterface
	{
		public string name {get; private set;}
		public List<Item> customerInventory = new List<Item>();
		private Object _lock = new Object();
		
		public Customer(string name)
		{
			this.name = name;
		}
		
		public bool buyItem(Item i, Store s) {

			if(s.findItem(i))
			{
				customerInventory.Add(i);
				s.sellItem(i);
				return true;
			}
			
			return false;
		}
	}
}
