using System;

namespace BazaarOfTheBizarre
{
	interface ItemInterface
	{
	}
	
	public class Item : ItemInterface
	{
		public string name {get; private set;}
		
		public Item(string name)
		{
			this.name = name;
		}
	}
}
