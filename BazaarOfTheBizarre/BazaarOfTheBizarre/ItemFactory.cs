using System;
using System.Collections.Generic;
using System.IO;

namespace BazaarOfTheBizarre
{
	/// <summary>
	/// Description of ItemFactory: Generates and returns a list of itemCount amount
	/// of Item objects, with random naming chosen from text-file: ItemNames.txt
	/// </summary>
	public class ItemFactory
	{
		public List<Item> generateItems(int itemCount) {
			List<Item> itemList = new List<Item>();
			string path = AppDomain.CurrentDomain.BaseDirectory;
			Random r = new Random(Guid.NewGuid().GetHashCode()); //seedverdien hentet fra https://stackoverflow.com/questions/1785744/how-do-i-seed-a-random-class-to-avoid-getting-duplicate-random-values
			if(path.EndsWith("\\bin\\Debug\\"))
			{
				path = path.Replace("\\bin\\Debug", "");
			}
			path = path + "ItemNames.txt";
			string[] allLines = File.ReadAllLines(path);
			for(int i = 0; i < itemCount; i++) 
			{
				string iName = allLines[r.Next(allLines.Length)].Trim();
				if(iName != "" && !iName.StartsWith("https:")) 
				{
					itemList.Add(new Item(iName));
				} else
				{
					i--;
				}
			}
			return itemList;
		}
	}
}
