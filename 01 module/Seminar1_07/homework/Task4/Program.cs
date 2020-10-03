using System;

namespace Task4
{
	class Program
	{
		static double[,] GetMatrix(int n, double min, double max)
		{
			double[,] a = new double[n, n];
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					a[i, j] = rnd.NextDouble() * (max - min) + min;
			return a;
		}
		static double Det2(double[,] a)
		{
			return a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];
		}
		static double Det3(double[,] a)
		{
			return (a[0, 0]*a[1, 1]*a[2, 2] + a[0, 1]*a[1, 2]*a[2, 0] + a[0, 2]*a[1, 0]*a[2, 1])
				- (a[0, 0]*a[1, 2]*a[2, 1] + a[0, 1] * a[1, 0] * a[2, 2] + a[0, 2] * a[1, 1] * a[2, 0]);
		}
		static void PrintMatrix(double[,] a)
		{
			Console.WriteLine();
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
					Console.Write($"{a[i, j]:f3} ");
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		static void Main(string[] args)
		{
			double min, max;
			do Console.Write($"Enter MIN: ");
			while (!double.TryParse(Console.ReadLine(), out min));
			do Console.Write($"Enter MAX: ");
			while (!double.TryParse(Console.ReadLine(), out max));

			double[,] matrix2 = GetMatrix(2, min, max);
			double[,] matrix3 = GetMatrix(3, min, max);
			PrintMatrix(matrix2);
			Console.WriteLine($"Determinant 2*2: {Det2(matrix2)}");
			PrintMatrix(matrix3);
			Console.WriteLine($"Determinant 3*3: {Det3(matrix3)}");
		}
	}
}
