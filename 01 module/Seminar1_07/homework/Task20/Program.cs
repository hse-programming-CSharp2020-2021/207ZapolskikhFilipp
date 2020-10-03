using System;

namespace Task20
{
	class Program
	{
		static void ArrayItemDouble(ref int[] a, int x)
		{
			int newLength = a.Length;
			foreach (int i in a)
				if (i == x)
					newLength++;
			int[] a2 = new int[newLength];
			int j = 0;
			for (int i = 0; i < a.Length; i++)
			{
				a2[j++] = a[i];
				if (a[i] == x)
					a2[j++] = a[i];
			}
			a = a2;
		}
		static int[] GetArray(int n)
		{
			int[] a = new int[n];
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
				a[i] = rnd.Next(10, 101);
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
			int n, y;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
			do Console.Write("Enter Y: ");
			while (!int.TryParse(Console.ReadLine(), out y) || y < 10 || y > 100);

			int[] array = GetArray(n);
			PrintArray(array);
			ArrayItemDouble(ref array, y);
			PrintArray(array);
		}
	}
}
