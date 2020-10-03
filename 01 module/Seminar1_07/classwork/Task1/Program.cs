using System;

namespace Task1
{
	class Program
	{
		static int[,] GetArray1(int n)
		{
			int[,] a = new int[n, n];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					a[i,j] = i > j ? -1 : (i < j ? 1 : 0);
			return a;
		}
		static int[,] GetArray2(int n)
		{
			int[,] a = new int[n, n];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					a[i, j] = i + j < n - 1 ? -1 : (i + j > n - 1 ? 1 : 0);
			return a;
		}
		static int[,] GetArray3(int n)
		{
			int[,] a = new int[n, n];
			int[] dx = { -1, 0, 1, 0 };
			int[] dy = { 0, 1, 0, -1 };
			int x = 0, y = 0, d = 1;
			for (int i = 1; i <= n * n; i++)
			{
				a[x, y] = i;
				if (x + dx[d] == n || y + dy[d] == n 
					|| x + dx[d] == -1 || y + dy[d] == -1 
					|| a[x + dx[d], y + dy[d]] != 0)
					d = (d + 1) % 4;
				x += dx[d];
				y += dy[d];
			}
			return a;
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
			int[,] array1 = GetArray1(n);
			int[,] array2 = GetArray2(n);
			int[,] array3 = GetArray3(n);
			PrintArray(array1);
			PrintArray(array2);
			PrintArray(array3);
		}
	}
}
