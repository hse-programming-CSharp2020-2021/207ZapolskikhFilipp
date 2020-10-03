using System;

namespace Task16
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
		static int MinimumIndex(int[] a)
		{
			int index = 0, minElement = a[0];
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] < minElement)
				{
					index = i;
					minElement = a[i];
				}
			}
			return index;
		}
		static int MaximumIndex(int[] a)
		{
			int index = 0, maxElement = a[0];
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] > maxElement)
				{
					index = i;
					maxElement = a[i];
				}
			}
			return index;
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
			
			int[] array = GetArray(n);
			PrintArray(array);
			Console.WriteLine($"Minimum index: {MinimumIndex(array)}");
			Console.WriteLine($"Sum of minimum index and maximum index: {MinimumIndex(array) + MaximumIndex(array)}");
		}
	}
}
