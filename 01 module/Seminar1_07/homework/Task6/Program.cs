using System;

namespace Task6
{
	class Program
	{
		static double[,] GetMatrix(int n, int m)
		{
			double[,] a = new double[n, m];
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					a[i, j] = rnd.NextDouble() * 20.0;
			return a;
		}
		static double Det3(double[,] a, int i)
		{
			int j = i * 3;
			return (a[0, j] * a[1, j+1] * a[2, j+2] + a[0, j+1] * a[1, j+2] * a[2, j] + a[0, j+2] * a[1, j] * a[2, j+1])
				- (a[0, j] * a[1, j+2] * a[2, j+1] + a[0, j+1] * a[1, j] * a[2, j+2] + a[0, j+2] * a[1, j+1] * a[2, j]);
		}
		static void PrintMatrix(double[,] a)
		{
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
					Console.Write($"{a[i, j]:f3}\t");
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		static void Main(string[] args)
		{
			double[,] matrix = GetMatrix(3, 6);
			PrintMatrix(matrix);
			double[] array = new double[2];
			for (int i = 0; i < 2; i++)
				array[i] = Det3(matrix, i);
			for (int i = 0; i < 2; i++)
				Console.Write($"{array[i]}\t");
		}
	}
}
