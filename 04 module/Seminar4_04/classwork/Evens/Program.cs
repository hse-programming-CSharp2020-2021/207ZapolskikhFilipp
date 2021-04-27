using System;
using System.Collections;
using System.Collections.Generic;

namespace Evens
{
	class Evens : IEnumerable<int>
	{
		readonly int a;
		readonly int b;

		public Evens(int a, int b)
		{
			this.a = a % 2 == 0 ? a : a + 1;
			this.b = b;
		}
		public IEnumerator<int> GetEnumerator()
		{
			for (int i = a; i <= b; i += 2)
				yield return i;
		}
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
	class Program
	{
		static void Main()
		{
			Evens ev = new(20, 43);
			foreach (var t in ev)
				Console.Write(t + "  ");
			Console.WriteLine();
			Console.ReadKey();
		}
	}
}
