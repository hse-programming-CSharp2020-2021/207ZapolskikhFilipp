using System;

namespace Task5
{
	class Program
	{
		static double[,] GetMatrix(int n)
		{
			double[,] a = new double[n, n];
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					a[i, j] = rnd.NextDouble() * 25.0;
			return a;
		}
		static bool F1(int i, int j, int n)
		{
			return i > j && i + j < n - 1;
		}
		static bool F2(int i, int j, int n)
		{
			return i >= j && i + j >= n - 1;
		}
		static bool F3(int i, int j, int n)
		{
			return (i - j) * (i + j - n + 1) > 0;
		}
		static bool F4(int i, int j, int n)
		{
			return (i - j) * (i + j - n + 1) > 0 && ((i < n / 2 && j < n / 2) || (i >= n / 2 && j >= n / 2));
		}
		static void PrintMatrix(double[,] a, int method)
		{
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
				{
					if ((method == 1 && F1(i, j, a.GetLength(0)))
						|| (method == 2 && F2(i, j, a.GetLength(0)))
						|| (method == 3 && F3(i, j, a.GetLength(0)))
						|| (method == 4 && F4(i, j, a.GetLength(0))))
						Console.Write($"{a[i, j]:f3}");
					else
						Console.Write('-');
					Console.Write('\t');
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

			double[,] a = GetMatrix(n);
			for (int i = 1; i <= 4; i++)
				PrintMatrix(a, i);
		}
	}
}
