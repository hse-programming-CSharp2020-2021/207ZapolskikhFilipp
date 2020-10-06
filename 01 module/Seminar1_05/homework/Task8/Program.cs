using System;

namespace Task8
{
	class Program
	{
		static double[] GetArray(int n)
		{
			double[] array = new double[n];
			for (int i = 0; i < n; i++)
				array[i] = (i * (i + 1) / 2) % n;
			return array;
		}
		static void Norm(double[] array)
		{
			double max = 0.0;
			foreach (double val in array)
				max = Math.Max(max, val);
			for (int i = 0; i < array.Length; i++)
				array[i] /= max;
		}
		static void PrintArray(double[] array)
		{
			foreach (double val in array)
				Console.Write(Math.Round(val, 3) + " ");
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			double[] array = GetArray(n);
			Console.Write("Old array: ");
			PrintArray(array);
			Norm(array);
			Console.Write("\nNew array: ");
			PrintArray(array);
		}
	}
}
