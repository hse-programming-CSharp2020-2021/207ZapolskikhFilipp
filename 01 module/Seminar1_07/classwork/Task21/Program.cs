using System;

namespace Task21
{
	class Program
	{
		static int S(int i, int j)
		{
			if (i == j)
				return 1;
			else if ((i > 0 && j == 0) || (i == 0 && j > 0))
				return 0;
			else if (i > j && j > 0)
				return S(i - 1, j - 1) + j * S(i - 1, j);
			else
				return int.MinValue;
		}
		static void PrintArray(int[,] a)
		{
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
				{
					Console.Write($"{a[i, j]}\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write($"Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			int k;
			do Console.Write($"Enter K: ");
			while (!int.TryParse(Console.ReadLine(), out k) || n <= 0);
			int[,] a = new int[n, k];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < k; j++)
					a[i, j] = S(i, j);
			PrintArray(a);
		}
	}
}
