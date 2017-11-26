using System;
using System.Collections.Generic;

namespace BazaarOfTheBizarre
{
	interface CustomerInterface
	{
		bool buyItem(Store s);
	}
	public class Customer : CustomerInterface
	{
		public string name {get; private set;}
		public List<Item> customerInventory = new List<Item>();
		
		public Customer(string name)
		{
			this.name = name;
		}
		
		//prøver å kjøpe vare som for øyeblikket er lagt til salgs og legger til i kjøpererns "inventory",
		//returnerer true om det går og false ellers.
		public bool buyItem(Store s) {
			if(s.itemForSale != null)
			{
				customerInventory.Add(s.itemForSale);
				return true;
			}
			return false;
		}
	}
}
