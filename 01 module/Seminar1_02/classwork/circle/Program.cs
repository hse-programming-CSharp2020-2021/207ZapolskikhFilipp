using System;

namespace circle
{
	class Program
	{
		public static double CircleLength(double r)
		{
			return 2.0 * Math.PI * r;
		}
		public static double CircleArea(double r)
		{
			return Math.PI * r * r;
		}
		static void Main(string[] args)
		{
			double r;
			Console.Write("Enter radius: ");
			if (!double.TryParse(Console.ReadLine(), out r) || r <= 0.0)
			{
				Console.WriteLine("Error!");
			}
			else
			{
				Console.WriteLine($"Length: {CircleLength(r):f2}");
				Console.WriteLine($"Area: {CircleArea(r):f2}");
			}
		}
	}
}
