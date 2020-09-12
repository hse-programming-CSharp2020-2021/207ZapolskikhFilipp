using System;

namespace fibonacci
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				uint n;
				Console.Write("Enter N: ");
				if (!uint.TryParse(Console.ReadLine(), out n))
				{
					Console.WriteLine("Error!");
					break;
				}
				else
				{
					double b = (1.0 + Math.Sqrt(5.0)) / 2.0;
					double u = (Math.Pow(b, n) - Math.Pow(-b, -n)) / (2.0 * b - 1.0);
					Console.WriteLine("Result: {0}", Math.Round(u));
				}
			}
		}
	}
}
