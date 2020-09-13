using System;

namespace Task2
{
	class Program
	{
		public static uint Reverse(uint x)
		{
			uint res = 0;
			while (x > 0)
			{
				res = res * 10 + x % 10;
				x /= 10;
			}
			return res;
		}
		static void Main(string[] args)
		{
			uint x;
			do
			{
				Console.Write("Enter a number: ");
			} while (!uint.TryParse(Console.ReadLine(), out x));
			Console.WriteLine($"Answer: {Reverse(x)}");
		}
	}
}
