using System;

namespace Task4
{
	class Program
	{
		static void Main(string[] args)
		{
			uint x, y = 0;
			do
			{
				Console.Write("Enter 4-digit number: ");
			} while (!uint.TryParse(Console.ReadLine(), out x) || x < 1000 || x > 9999);

			for (int i = 0; i < 4; i++)
			{
				y = y * 10 + x % 10;
				x /= 10;
			}

			Console.WriteLine($"Answer: {y}");
		}
	}
}
