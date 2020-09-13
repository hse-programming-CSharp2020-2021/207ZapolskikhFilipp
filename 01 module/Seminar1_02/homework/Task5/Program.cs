using System;

namespace Task5
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
			bool triangle = a + b > c ? (a + c > b ? (b + c > a) : false) : false;
			Console.WriteLine(triangle ? "It's a triangle" : "It's not a triangle!");
		}
	}
}
