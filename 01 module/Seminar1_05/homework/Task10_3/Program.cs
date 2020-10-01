using System;

namespace Task10_3
{
	class Program
	{
		static int[] GetArray(int n, int a, int d)
		{
			int[] array = new int[n];
			for (int i = 0; i < n; i++)
				array[i] = a + i * d;
			return array;
		}
		static void PrintArray(int[] array)
		{
			foreach (int val in array)
				Console.Write(val + " ");
		}
		static void Main(string[] args)
		{
			int n, a, d;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 1);
			do Console.Write("Enter A: ");
			while (!int.TryParse(Console.ReadLine(), out a));
			do Console.Write("Enter D: ");
			while (!int.TryParse(Console.ReadLine(), out d));
			int[] array = GetArray(n, a, d);
			Console.Write("Array: ");
			PrintArray(array);
		}
	}
}
