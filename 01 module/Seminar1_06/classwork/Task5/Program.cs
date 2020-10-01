using System;

namespace Task5
{
	class Program
	{
		static void Shrink(ref int[] array)
		{
			int newLength = 0;
			for (int i = 0; i < array.Length; i++)
				if (array[i] % 2 == 1)
					array[newLength++] = array[i];
			if (newLength > 0)
				Array.Resize(ref array, newLength);
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			int[] array = new int[n];
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
				array[i] = rnd.Next(-10, 11);
			Array.ForEach(array, x => Console.Write($"{x} "));
			Console.WriteLine();
			Shrink(ref array);
			Array.ForEach(array, x => Console.Write($"{x} "));
		}
	}
}
