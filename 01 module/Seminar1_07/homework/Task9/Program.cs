using System;

namespace Task9
{
	class Program
	{
		//0, 1, 2, 3, 4, 5, 6 -> 0, 2, 4, 6, 5, 3, 1
		static void ArrayHill(double[] a)
		{
			double[] a2 = (double[])a.Clone();
			Array.Sort(a2);
			for (int i = 0; i < a.Length; i++)
			{
				if (i * 2 < a.Length)
					a[i] = a2[i * 2];
				else
					a[i] = a2[1 + 2 * (a.Length - i - 1)];
			}
		}
		static double[] GetArray(int n)
		{
			double[] a = new double[n];
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
				a[i] = rnd.Next(-10, 11);
			return a;
		}
		static void PrintArray(double[] a)
		{
			foreach (double val in a)
				Console.Write($"{val} ");
			Console.WriteLine();
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			double[] array = GetArray(n);
			PrintArray(array);
			ArrayHill(array);
			PrintArray(array);
		}
	}
}
