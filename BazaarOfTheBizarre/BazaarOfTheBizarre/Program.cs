using System;

namespace BazaarOfTheBizarre
{
	/// <summary>
	/// Description of Program.
	/// </summary>
	public static class Program
	{
		public static void Main(string [] args)
		{	
			Store s = new Store("Bazaar of the Bizarre", null);
			s.newDay();
			//Console.ReadKey(true);
		}
	}
}
