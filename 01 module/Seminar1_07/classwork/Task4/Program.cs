using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Task4
{
	class Program
	{
		static void PrintArray(int[] a)
		{
			foreach (int val in a)
				Console.Write($"{val} ");
			Console.WriteLine();
		}
		static void Main(string[] args)
		{
			int[] a = new int[10];
			Random rnd = new Random();
			for (int i = 0; i < 10; i++)
				a[i] = rnd.Next(-10, 11);
			PrintArray(a);
			Array.Sort(a, (x, y) =>
			{
				if (x >= 0 && y < 0)
					return -1;
				else if (x < 0 && y >= 0)
					return 1;
				else
					return 0;
			});
			PrintArray(a);
		}
	}
}
