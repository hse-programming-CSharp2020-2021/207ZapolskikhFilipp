using System;
using System.Collections.Generic;

namespace Fibonacci
{
	class Fibbonacci
	{
		int last1;
		int last2;

		public IEnumerable<int> NextMemb(int count)
		{
			last1 = last2 = 1;
			yield return 1;
			yield return 1;
			for (int i = 2; i < count; i++)
			{
				int current = last1 + last2;
				last1 = last2;
				last2 = current;
				yield return current;
			}
		}
	}
	class TriangleNums
	{
		public static IEnumerable<int> NextMemb(int count)
		{
			for (int i = 0; i < count; i++)
				yield return i * (i + 1) / 2;
		}
	}
	class Program
	{
		static void Main()
		{
			int m;
			do
				Console.Write("Enter M: ");
			while (!int.TryParse(Console.ReadLine(), out m) || m < 1);
			Fibbonacci fi = new();
			foreach (int numb in fi.NextMemb(m))
				Console.Write(numb + "  ");
			Console.WriteLine();
			foreach (int numb in TriangleNums.NextMemb(m))
				Console.Write(numb + "  ");
			Console.WriteLine();
			IEnumerator<int> enum1 = fi.NextMemb(m).GetEnumerator();
			foreach (int numb in TriangleNums.NextMemb(m))
			{
				enum1.MoveNext();
				Console.Write((numb + enum1.Current) + "  ");
			}
		}
	}
}
