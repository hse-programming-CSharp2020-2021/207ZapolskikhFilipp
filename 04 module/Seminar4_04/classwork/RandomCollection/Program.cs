using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomCollection
{
	class RandomCollection : IEnumerable<int>
	{
		readonly int n;

		public RandomCollection(int n) => this.n = n;
		public IEnumerator<int> GetEnumerator() => new RandomEnumerator(n);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private class RandomEnumerator : IEnumerator<int>
		{
			readonly int n;
			int position = -1;
			readonly Random rnd = new();

			public RandomEnumerator(int n) => this.n = n;
			public void Dispose() { }
			public bool MoveNext() => ++position < n;
			public void Reset() => position = -1;

			public int Current
			{
				get
				{
					if (position >= n)
						throw new IndexOutOfRangeException();
					return rnd.Next();
				}
			}
			object IEnumerator.Current => Current;
		}
	}
	class Program
	{
		static void Main()
		{
			int n = 10;
			RandomCollection collection = new(n);
			foreach (int i in collection)
				Console.Write($"{i} ");
			Console.WriteLine();
			foreach (int i in collection)
				Console.Write($"{i} ");
		}
	}
}
