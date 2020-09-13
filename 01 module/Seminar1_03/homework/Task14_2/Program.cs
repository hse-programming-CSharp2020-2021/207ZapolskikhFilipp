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
		public static double G(double x, double y)
		{
			if (x < y && x > 0)
				return x + Math.Sin(y);
			else if (x > y && x < 0)
				return y - Math.Cos(x);
			else
				return 0.5 * x * y;
		}
		static void Main(string[] args)
		{
			double x = In("X"), y = In("Y");
			Console.WriteLine($"Answer: {G(x, y)}");
		}
	}
}
