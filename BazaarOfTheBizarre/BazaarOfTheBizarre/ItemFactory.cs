using System;
using System.Collections.Generic;
using System.IO;

namespace BazaarOfTheBizarre
{
	public class ItemFactory
	{
		//Genererer og returnerer en liste over varer med tilfeldige navn - hentet fra en navnefil
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
