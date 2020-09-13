using System;

namespace Task7
{
	class Program
	{
		public static double Integer(double x, out double fractional)
		{
			fractional = x - (int)x;
			return (int)x;
		}
		public static double Square(double x, ref double sqrt)
		{
			if (x >= 0.0)
				sqrt = Math.Sqrt(x);
			return x * x;
		}
		static void Main(string[] args)
		{
			double x, frac, sqrt = 0.0;
			do
			{
				Console.Write("Enter a number: ");
			} while (!double.TryParse(Console.ReadLine(), out x));
			Console.Write($"Integer={Integer(x, out frac)}, fractional={frac}, square={Square(x, ref sqrt)}");
			Console.WriteLine(x >= 0.0 ? $", sqrt={sqrt}" : "");
		}
	}
}
