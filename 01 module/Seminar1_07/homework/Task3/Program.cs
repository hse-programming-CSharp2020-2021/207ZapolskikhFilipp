using System;

namespace Task3
{
	class Program
	{
		static char[][] GetArray1(int n)
		{
			char[][] a = new char[n][];
			for (int i = 0; i < n; i++)
			{
				a[i] = new char[i + 1];
				for (int j = 0; j <= i; j++)
					a[i][j] = '*';
			}
			return a;
		}
		static char[][] GetArray2(int n)
		{
			char[][] a = new char[n][];
			for (int i = 0; i < n; i++)
			{
				a[i] = new char[Math.Min(n, n / 2 + i + 1)];
				int start = Math.Max(n / 2 - i, 0);
				for (int j = 0; j < start; j++)
					a[i][j] = ' ';
				for (int j = start; j < a[i].Length; j++)
					a[i][j] = '*';
			}
			return a;
		}
		static void PrintArray(char[][] a)
		{
			foreach (char[] c in a)
			{
				foreach (char val in c)
					Console.Write($"{val} ");
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write($"Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			char[][] array1 = GetArray1(n);
			PrintArray(array1);
			char[][] array2 = GetArray2(n);
			PrintArray(array2);
		}
	}
}
