using System;

namespace Task10_4
{
	class Program
	{
		static int[] GetArray(int n)
		{
			int[] array = new int[n];
			if (n >= 1)
				array[0] = 1;
			if (n >= 2)
				array[1] = 1;
			for (int i = 2; i < n; i++)
				array[i] = array[i - 1] + array[i - 2];
			return array;
		}
		static void PrintArray(int[] array)
		{
			for (int i = array.Length - 1; i >= 0; i--)
				Console.Write(array[i] + " ");
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			int[] array = GetArray(n);
			Console.Write("Array: ");
			PrintArray(array);
		}
	}
}
