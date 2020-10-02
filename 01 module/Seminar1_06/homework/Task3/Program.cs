using System;

namespace Task3
{
	class Program
	{
		static double[] GetSin1(int n)
		{
			double[] array = new double[n];
			array[0] = 1.0;
			for (int i = 1; i < n; i++)
				array[i] = -array[i - 1] / (i * 2.0) / (i * 2.0 + 1.0);
			return array;
		}
		static double GetSinX(double x, ref double[] array)
		{
			double pow = x;
			double sum = 0.0;
			for (int i = 0; i < array.Length; i++)
			{
				sum += array[i] * pow;
				pow = pow * x * x;
			}
			return sum;
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write($"Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

			while (true)
			{
				double[] array = GetSin1(n);
				double x;
				do Console.Write($"Enter X: ");
				while (!double.TryParse(Console.ReadLine(), out x));
				Console.WriteLine($"My sin(x): {GetSinX(x, ref array)}\tMath.Sin(x): {Math.Sin(x)}");
			}
		}
	}
}
