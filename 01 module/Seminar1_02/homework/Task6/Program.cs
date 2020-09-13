using System;
using System.Globalization;

namespace Task6
{
	class Program
	{
		static void Main(string[] args)
		{
			double x;
			uint p;
			do
			{
				Console.Write("Enter your budget ($): ");
			} while (!double.TryParse(Console.ReadLine(), out x) || x <= 0.0);
			do
			{
				Console.Write("Enter the percentage of the budget for computer games: ");
			} while (!uint.TryParse(Console.ReadLine(), out p) || p < 0 || p > 100);
			
			Console.WriteLine(string.Format(new CultureInfo("en-US"), "{0:c} for computer games", x * p / 100.0));
		}
	}
}
