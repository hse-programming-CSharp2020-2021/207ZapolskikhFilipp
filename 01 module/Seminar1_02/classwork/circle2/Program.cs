using System;

namespace circle2
{
	class Program
	{
		static void Main(string[] args)
		{
			int x, y;
			if (!int.TryParse(Console.ReadLine(), out x) || !int.TryParse(Console.ReadLine(), out y))
			{
				Console.WriteLine("Error!");
			}
			else
			{
				Console.WriteLine(InCircle(x, y) ? "In circle" : "Out of circle");
			}
		}

		private static bool InCircle(int x, int y)
		{
			return x * x + y * y <= 100;
		}
	}
}
