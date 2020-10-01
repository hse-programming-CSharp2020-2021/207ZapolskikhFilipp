using System;

namespace Task7
{
	class Program
	{
		static void Main(string[] args)
		{
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			char[] array = n.ToString().ToCharArray();
			Array.ForEach(array, x => Console.Write($"{x} "));
		}
	}
}
