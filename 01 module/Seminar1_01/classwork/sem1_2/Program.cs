using System;

namespace sem1_2
{
	class Program
	{
		public static void Main(string[] args)
		{
			string sa = Console.ReadLine();
			string sb = Console.ReadLine();
			int a, b;
			bool ba = int.TryParse(sa, out a);
			bool bb = int.TryParse(sb, out b);
			if (ba && bb)
			{
				Console.WriteLine(a + b);
			}
			else
			{
				Console.WriteLine("Error!");
			}
		}
	}
}
