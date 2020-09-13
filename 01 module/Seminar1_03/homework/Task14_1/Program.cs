using System;

namespace Task14_1
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
		public static bool G(double x, double y)
		{
			return x * x + y * y <= 4.0 && x >= 0 && y <= x;
		}
		static void Main(string[] args)
		{
			double x = In("X"), y = In("Y");
			Console.WriteLine($"Answer: {G(x, y)}");
		}
	}
}
