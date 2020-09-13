using System;

namespace Task14_4
{
	class Program
	{
		public static uint In(string name)
		{
			uint res;
			do
			{
				Console.Write($"Enter {name}: ");
			} while (!uint.TryParse(Console.ReadLine(), out res) || res < 101 || res > 999);
			return res;
		}
		static void Main(string[] args)
		{
			uint a = In("classroom 1"), b = In("classroom 2"), c = In("classroom 3");
			uint min = Math.Min(Math.Min(a % 100, b % 100), c % 100);
			Console.WriteLine($"Answer: {(a % 100 == min ? a : (b % 100 == min ? b : c))}");
		}
	}
}
