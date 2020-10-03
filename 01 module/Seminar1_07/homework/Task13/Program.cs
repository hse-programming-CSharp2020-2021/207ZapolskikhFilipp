using System;

namespace Task13
{
	class Program
	{
		static int[] GetArray(int n)
		{
			int[] a = new int[n];
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
				a[i] = rnd.Next(-100, 101);
			return a;
		}
		static void PrintArray(int[] a)
		{
			foreach (int val in a)
				Console.Write($"{val} ");
			Console.WriteLine();
		}
		static void Main(string[] args)
		{
			int n, k;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
			do Console.Write("Enter K: ");
			while (!int.TryParse(Console.ReadLine(), out k) || k < 1 || k > n);

			int[] a = GetArray(n);
			PrintArray(a);
			for (int i = 1; i * k < n; i++)
				Console.Write($"{a[i * k]} ");
		}
	}
}
