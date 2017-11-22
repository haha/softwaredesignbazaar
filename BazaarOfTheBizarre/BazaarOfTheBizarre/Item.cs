using System;

namespace BazaarOfTheBizarre
{
	
	interface ItemInterface
	{
		/*
		void setName(string s);
		String getName();
		void setDescription(string s);
		String getDescription(); */
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
			//setName(name);
			//setDescription(description);
		}
		/*
		public void setName(string name)
		{
			this.name = name;
		}
		public string getName()
		{
			return name;
		}
		
		public void setDescription(string description) 
		{
			this.description = description;
		}
		public string getDescription()
		{
			return description;
		}*/
	}
}
