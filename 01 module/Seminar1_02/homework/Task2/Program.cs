using System;

namespace Task2
{
	class Program
	{
		public static void Sort(ref uint a, ref uint b, ref uint c)
		{
			uint a0, b0, c0;
			a0 = a < b ? (a < c ? a : c) : (c < b ? c : b);
			c0 = a > b ? (a > c ? a : c) : (c > b ? c : b);
			b0 = a + b + c - a0 - c0;
			a = a0;
			b = b0;
			c = c0;
		}
		public static uint Solve(uint p)
		{
			uint a, b, c;
			a = p % 10;
			p /= 10;
			b = p % 10;
			p /= 10;
			c = p;
			Sort(ref a, ref b, ref c);
			return c * 100 + b * 10 + a;
		}
		static void Main(string[] args)
		{
			uint p;
			do
			{
				Console.Write("Enter P: ");
			} while (!uint.TryParse(Console.ReadLine(), out p) || p < 100 || p > 999);
			Console.WriteLine($"Answer: {Solve(p)}");
		}
	}
}
