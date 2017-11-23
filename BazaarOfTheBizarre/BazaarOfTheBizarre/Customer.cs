using System;

namespace BazaarOfTheBizarre
{
	interface CustomerInterface 
	{
		bool buyItem(Item i);
	}
	
	/// <summary>
	/// Description of Customer.
	/// </summary>
	public class Customer : CustomerInterface
	{
		public string name {get; private set;}
		public Customer(string name)
		{
			this.name = name;
		}
		
		public bool buyItem(Item i) {
			return true;
		}
	}
}
