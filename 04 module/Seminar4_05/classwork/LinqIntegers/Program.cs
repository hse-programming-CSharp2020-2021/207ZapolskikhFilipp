using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqIntegers
{
	class Program
	{
		static void Solve(int[] array)
		{
			Print(array, "Source");
			Print(array.Select(x => x * x), "Query 1");
			Print(array.Where(x => x > 0 && Math.Abs(x).ToString().Length == 2), "Query 2");
			Print(array.Where(x => x % 2 == 0).OrderByDescending(x => x), "Query 3");
			var query4 = array.GroupBy(x => Math.Abs(x).ToString().Length).Select(group => $"{{{string.Join(' ', group)}}}");
			Console.WriteLine($"Query 4: " + string.Join(", ", query4.ToArray()));
		}
		static void Print(IEnumerable<int> numbers, string name)
		{
			Console.Write($"{name}: ");
			foreach (int i in numbers)
				Console.Write($"{i} ");
			Console.WriteLine();
		}
		static void Main()
		{
			int n;
			do
				Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
			int[] array = new int[n];
			Random rnd = new();
			for (int i = 0; i < n; i++)
				array[i] = rnd.Next(-1000, 1001);
			Solve(array);
		}
	}
}
