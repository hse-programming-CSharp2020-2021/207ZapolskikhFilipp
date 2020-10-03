using System;

namespace Task3
{
	class Program
	{
		static char[][] GetArray(int n)
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
		static void PrintArray(char[][] a)
		{
			foreach (char[] c in a)
			{
				foreach (char val in c)
					Console.Write($"{val} ");
				Console.WriteLine();
			}
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write($"Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			char[][] array = GetArray(n);
			PrintArray(array);
		}
	}
}
