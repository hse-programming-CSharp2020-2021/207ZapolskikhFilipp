using System;

namespace Task11
{
	class Program
	{
		static long[] GetArray(int n)
		{
			long[] s = new long[n];
			s[0] = 0;
			if (n > 1)
				s[1] = 1;
			for (int i = 2; i < n; i++)
				s[i] = 34 * s[i - 1] - s[i - 2] + 2;
			return s;
		}
		static void PrintArray(long[] a)
		{
			foreach (long val in a)
				Console.Write($"{val} ");
			Console.WriteLine();
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			long[] array = GetArray(n);
			PrintArray(array);
		}
	}
}
