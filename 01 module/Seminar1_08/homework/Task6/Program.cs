using System;

namespace Task6
{
	class Program
	{
		static void PrintArray(int[] array)
		{
			Array.ForEach(array, x => Console.Write($"{x} "));
			Console.WriteLine();
		}
		static double Average(int[] array)
		{
			int sum = 0;
			Array.ForEach(array, x => sum += x);
			return (double)sum / array.Length;
		}
		static void Main(string[] args)
		{
			Console.Write("Enter values separated by ';': ");
			int[] intArray = Array.ConvertAll(Array.FindAll(Console.ReadLine().Split(';'),
				x => int.TryParse(x, out int i)), x => int.Parse(x));
			PrintArray(intArray);
			Console.WriteLine($"Average: {Average(intArray)}");
		}
	}
}
