using System;

namespace Task1
{
	class Program
	{
		public static double F(double x)
		{
			double res = 0.0, m = 1.0;
			for (int i = 0; i <= 4; i++) //-4, 2, -3, 9, 12
			{
				double k;
				if (i == 0)
					k = -4.0;
				else if (i == 1)
					k = 2.0;
				else if (i == 2)
					k = -3.0;
				else if (i == 3)
					k = 9.0;
				else
					k = 12.0;
				res += k * m;
				m *= x;
			}
			return res;
		}
		static void Main(string[] args)
		{
			double x;
			do
			{
				Console.Write("Enter X: ");
			} while (!double.TryParse(Console.ReadLine(), out x));
			Console.WriteLine($"F({x}) = {F(x)}");
		}
	}
}
