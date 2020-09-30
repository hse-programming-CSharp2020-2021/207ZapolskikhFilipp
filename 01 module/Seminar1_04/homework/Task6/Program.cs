using System;

namespace Task6
{
	class Program
	{
		static double S1(double x)
		{
			double sum = 0.0;
			double mult = x * x;
			int c = 2;
			while (mult != 0.0)
			{
				mult = -mult * 4.0 * x * x / (c + 1) / (c + 2);
				c += 2;
				sum += mult;
			}
			return sum;
		}
		static double S2(double x)
		{
			double sum = 0.0;
			double mult = 1;
			int c = 0;
			while (mult != 0.0)
			{
				c++;
				mult = mult * x / c;
				sum += mult;
			}
			return sum;
		}
		static void Main(string[] args)
		{
			double x;
			Console.Write("Enter X: ");
			if (!double.TryParse(Console.ReadLine(), out x))
			{
				Console.WriteLine("Incorrect input");
				return;
			}
			Console.WriteLine($"S1 = {S1(x)}");
			Console.WriteLine($"S2 = {S2(x)}");
		}
	}
}
