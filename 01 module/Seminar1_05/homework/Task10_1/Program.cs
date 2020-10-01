using System;

namespace Task10_1
{
	class Program
	{
		static int[] GetArray(int n)
		{
			int[] array = new int[n];
			int cur = 1;
			for (int i = 0; i < n; i++)
			{
				array[i] = cur;
				cur <<= 1;
			}
			return array;
		}
		static void PrintArray(int[] array)
		{
			foreach (int val in array)
				Console.Write(val + " ");
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > 31);
			int[] array = GetArray(n);
			Console.Write("Array: ");
			PrintArray(array);
		}
	}
}
