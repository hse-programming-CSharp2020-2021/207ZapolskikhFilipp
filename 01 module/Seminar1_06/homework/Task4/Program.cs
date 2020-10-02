using System;

namespace Task4
{
	class Program
	{
		static uint[] GetArray(uint a0)
		{
			uint[] a = new uint[8];
			a[0] = a0;
			for (int i = 1; ; i++)
			{
				if (i >= a.Length)
					Array.Resize(ref a, a.Length * 2);
				a[i] = a[i - 1] % 2 == 0 ? a[i - 1] / 2 : (3 * a[i - 1] + 1);
				if (a[i] == 1)
					break;
			}
			return a;
		}
		static void PrintArray(uint[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 5 == 0)
					Console.WriteLine();
				Console.Write($"[{i}]={array[i]}\t");
				if (array[i] == 1)
					break;
			}
		}
		static void Main(string[] args)
		{
			uint a0;
			do Console.Write("Enter A0: ");
			while (!uint.TryParse(Console.ReadLine(), out a0));
			PrintArray(GetArray(a0));
		}
	}
}
