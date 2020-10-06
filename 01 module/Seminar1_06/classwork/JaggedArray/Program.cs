using System;

namespace JaggedArray
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] a = new int[5][];
			Random rnd = new Random();

			for (int i = 0; i < a.Length; i++)
				a[i] = new int[rnd.Next(5, 9)];

			for (int i = 0; i < a.Length; i++)
				for (int j = 0; j < a[i].Length; j++)
					a[i][j] = rnd.Next(-10, 11);

			for (int i = 0; i < a.Length; i++)
			{
				for (int j = 0; j < a[i].Length; j++)
					Console.Write($"{a[i][j]} ");
				Console.WriteLine();
			}
		}
	}
}
