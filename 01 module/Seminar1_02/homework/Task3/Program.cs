using System;

namespace Task3
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
		static void Main(string[] args)
		{
			double a = In("A"), b = In("B"), c = In("C");
			double d = b * b - 4 * a * c;
			int count = d < 0.0 ? 0 : (d == 0.0 ? 1 : 2);
			Console.WriteLine(a == 0.0 ? "Equation is not quadratic!" : 
				(count == 0 ? "No roots" : 
				(count == 1 ? $"X = {-b / (2.0 * a)}" : 
				$"X1 = {(-b - Math.Sqrt(d)) / (2.0 * a)}, X2 = {(-b + Math.Sqrt(d)) / (2.0 * a)}")));
		}
	}
}
