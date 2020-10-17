using System;
using System.Collections.Generic;
using System.Numerics;

namespace Variant18
{
	class Program
	{
		static void GetArrays(int n, out double[] a1, out double[] a2)
		{
			Random rnd = new Random();
			a1 = new double[n];
			a2 = new double[n];
			for (int i = 0; i < n; i++)
			{
				a1[i] = rnd.NextDouble() * 10.0 - 5.0;
				a2[i] = rnd.NextDouble() * 10.0 - 5.0;
			}
		}
		static void PrintArray(string text, double[] a)
		{
			if (a == null)
			{
				Console.WriteLine($"There is no array {text}");
				return;
			}
			Console.Write($"Array {text}: ");
			Array.ForEach(a, x => Console.Write($"{x:f3} "));
			Console.WriteLine();
		}
		static bool In(double x, double y)
		{
			return x * x + y * y >= 4.0 && x * x + y * y <= 16.0;
		}
		static void Partition(double[] x, double[] y, out double[] xin, out double[] yin, out double[] xout, out double[] yout)
		{
			int n = x.Length;
			double[][] a = new double[4][];
			int[] j = new int[4];
			for (int i = 0; i < 4; i++)
				a[i] = new double[n];
			for (int i = 0; i < n; i++)
			{
				if (In(x[i], y[i]))
				{
					a[0][j[0]++] = x[i];
					a[1][j[1]++] = y[i];
				}
				else
				{
					a[2][j[2]++] = x[i];
					a[3][j[3]++] = y[i];
				}
			}
			for (int i = 0; i < 4; i++)
			{
				if (j[i] == 0)
					a[i] = null;
				else
					Array.Resize(ref a[i], j[i]);
			}
			xin = a[0];
			yin = a[1];
			xout = a[2];
			yout = a[3];
		}
		static void Main(string[] args)
		{
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

			double[] x, y, xin, yin, xout, yout;
			GetArrays(n, out x, out y);
			PrintArray("X", x);
			PrintArray("Y", y);
			Partition(x, y, out xin, out yin, out xout, out yout);
			PrintArray("Xin", xin);
			PrintArray("Yin", yin);
			PrintArray("Xout", xout);
			PrintArray("Yout", yout);
		}
	}
}
