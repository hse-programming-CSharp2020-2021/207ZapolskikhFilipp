using System;

namespace Task6
{
	class Program
	{
		static bool ShrinkArray(ref int[] array)
		{
			int length = array.Length;
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] == int.MinValue)
					continue;
				if ((array[i] + array[i + 1]) % 3 == 0)
				{
					array[i] = array[i] * array[i + 1];
					array[i + 1] = int.MinValue;
					length--;
				}
			}
			if (array.Length == length)
				return false;
			int j = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != int.MinValue)
					array[j++] = array[i];
			}
			Array.Resize(ref array, length);
			return true;
		}
		static int ProcessArray(ref int[] array)
		{
			int i;
			for (i = 0; ShrinkArray(ref array); i++)
				PrintArray($"{i + 1}. ", array);
			return i;
		}
		static void PrintArray(string what, int[] array)
		{
			Console.Write(what);
			foreach (int i in array)
				Console.Write($"{i} ");
			Console.WriteLine();
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write($"Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			int[] array = new int[n];
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
				array[i] = rnd.Next(-10, 11);
			PrintArray("Source array: ", array);
			Console.WriteLine($"Shrink count: {ProcessArray(ref array)}");
		}
	}
}
