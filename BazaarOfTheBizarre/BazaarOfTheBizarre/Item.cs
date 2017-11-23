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
		public string description {get; private set;}
		
		public Item(string name, string description)
		{
			this.name = name;
			this.description = description;
		}
	}
}
