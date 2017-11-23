using System;

namespace BazaarOfTheBizarre
{
	
	interface ItemInterface
	{
	}
	
	/// <summary>
	/// Description of Item.
	/// </summary>
	public class Item : ItemInterface
	{
		public string name {get; private set;}
		
		public Item(string name)
		{
			this.name = name;
		}
	}
}
