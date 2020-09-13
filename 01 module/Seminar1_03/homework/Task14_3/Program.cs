using System;

namespace Task14_2
{
	class Program
	{
		public static double In(string name)
		{
			double res;
			do
			{
				Console.Write($"Enter {name}: ");
			} while (!double.TryParse(Console.ReadLine(), out res));
			return res;
		}
		public static double G(double x)
		{
			if (x <= 0.5)
				return Math.Sin(Math.PI / 2.0);
			else
				return Math.Sin(Math.PI * (x - 1.0) / 2.0);
		}
		static void Main(string[] args)
		{
			double x = In("X");
			Console.WriteLine($"Answer: {G(x)}");
		}
	}
}
