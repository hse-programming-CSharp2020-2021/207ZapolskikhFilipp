using System;
using System.Linq;

namespace LinqIntegers
{
	class Program
	{
		static void Main()
		{
			int n;
			do
				Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
			int[] array = new int[n];
			Random rnd = new();
			for (int i = 0; i < n; i++)
				array[i] = rnd.Next(-10000, 10001);
			Console.WriteLine($"Array: {string.Join(' ', array)}");
			Solve(array);
		}
		static void Solve(int[] array)
		{
			var query1 = from num in array
						 select Math.Abs(num) % 10;
			var query1_1 = array.Select(num => Math.Abs(num) % 10);
			Console.WriteLine($"Query 1: {string.Join(' ', query1)}");
			Console.WriteLine($"Query 1: {string.Join(' ', query1_1)}");

			var query2 = from num in array
						 group num by Math.Abs(num) % 10 into lastDigit
						 select lastDigit;
			var query2_1 = array.GroupBy(num => Math.Abs(num) % 10);
			Console.WriteLine($"Query 2: {string.Join(", ", query2.Select(group => $"{{{string.Join(' ', group)}}}"))}");
			Console.WriteLine($"Query 2: {string.Join(", ", query2_1.Select(group => $"{{{string.Join(' ', group)}}}"))}");

			var query3 = from num in array
						 where num % 2 == 0 && num > 0
						 select num;
			var query3_1 = array.Where(num => num % 2 == 0 && num > 0);
			Console.WriteLine($"Query 3: {query3.Count()} {{{string.Join(' ', query3)}}}");
			Console.WriteLine($"Query 3: {query3_1.Count()} {{{string.Join(' ', query3_1)}}}");

			var query4 = (from num in array
						  where num % 2 == 0
						  select num).Sum();
			var query4_1 = array.Where(num => num % 2 == 0).Sum();
			Console.WriteLine($"Query 4: {query4}");
			Console.WriteLine($"Query 4: {query4_1}");

			var query5 = from num in array
						 orderby Math.Abs(num).ToString()[0], Math.Abs(num) % 10
						 select num;
			var query5_1 = array.OrderBy(num => Math.Abs(num).ToString()[0]).ThenBy(num => Math.Abs(num) % 10);
			Console.WriteLine($"Query 5: {string.Join(' ', query5)}");
			Console.WriteLine($"Query 5: {string.Join(' ', query5_1)}");
		}
	}
}
