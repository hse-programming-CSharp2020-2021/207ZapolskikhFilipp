using System;

namespace Task9
{
	class Program
	{
		static int[] GetArray()
		{
			Random rnd = new Random();
			int[] array = new int[rnd.Next(3, 11)];
			for (int i = 0; i < array.Length; i++)
				array[i] = rnd.Next(0, 100);
			return array;
		}
		static void PrintArray(int[] array)
		{
			foreach (int val in array)
				Console.Write(val + " ");
		}
		static void ReplaceMaximums(int[] array, int x)
		{
			int max = 0;
			foreach (int val in array)
				max = Math.Max(max, val);
			for (int i = 0; i < array.Length; i++)
				if (array[i] == max)
					array[i] = x;
		}
		static void Main(string[] args)
		{
			int x;
			do Console.Write("Enter a number: ");
			while (!int.TryParse(Console.ReadLine(), out x));
			int[] array = GetArray();
			Console.Write("Old array: ");
			PrintArray(array);
			ReplaceMaximums(array, x);
			Console.Write("\nNew array: ");
			PrintArray(array);
		}
	}
}
