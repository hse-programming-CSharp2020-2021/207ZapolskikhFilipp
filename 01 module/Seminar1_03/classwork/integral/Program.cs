using System;

namespace integral
{
	class Program
	{
		public static double F(double x)
		{
			return x * x;
		}
		public static double Solve(double a, double delta)
		{
			double res = 0.0;
			int n = (int)(a / delta);
			for (int i = 0; i <= n; i++)
			{
				double d = delta * i, d2 = d + delta;
				if (d2 <= a)
				{
					res += (F(d) + F(d2)) * delta / 2.0;
				}
				else
				{
					res += (F(d) + F(a)) * (a - d) / 2.0;
				}
			}
			return res;
		}
		static void Main(string[] args)
		{
			double a, delta;
			Console.Write("Enter A: ");
			if (!double.TryParse(Console.ReadLine(), out a) || a <= 0.0)
			{
				Console.WriteLine("Error!");
				return;
			}
			Console.Write("Enter delta: ");
			if (!double.TryParse(Console.ReadLine(), out delta) || delta <= 0.0 || delta >= a)
			{
				Console.WriteLine("Error!");
				return;
			}
			Console.WriteLine($"Answer: {Solve(a, delta)}");
		}
	}
}
