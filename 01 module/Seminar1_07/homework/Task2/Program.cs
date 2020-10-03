using System;

namespace Task2
{
	class Program
	{
		static int[][] GetArray(int n)
		{
			int rowCount = 0;
			int count = 0;
			for (int i = 1; count < n; i++)
			{
				rowCount++;
				count += i;
			}
			int[][] a = new int[rowCount][];
			for (int i = 0; i < a.Length; i++)
			{
				a[i] = new int[Math.Min(i + 1, n)];
				for (int j = 0; j < a[i].Length; j++)
					a[i][j] = n--;
			}
			return a;
		}
		static void PrintArray(int[][] a)
		{
			foreach (int[] r in a)
			{
				foreach (int i in r)
					Console.Write($"{i}\t");
				Console.WriteLine();
			}
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
			PrintArray(GetArray(n));
		}
	}
}
