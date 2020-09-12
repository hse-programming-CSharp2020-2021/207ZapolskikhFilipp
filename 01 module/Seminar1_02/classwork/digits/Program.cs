using System;

namespace digits
{
	class Program
	{
		static void Main(string[] args)
		{
			int x;
			if (!int.TryParse(Console.ReadLine(), out x))
			{
				Console.WriteLine("Error!");
			}
			else
			{
				Console.WriteLine(x / 100);
				Console.WriteLine((x % 100) / 10);
				Console.WriteLine(x % 10);
			}
		}
	}
}
