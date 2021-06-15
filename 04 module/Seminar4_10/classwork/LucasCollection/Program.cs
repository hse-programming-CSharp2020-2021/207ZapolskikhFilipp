using System;
using System.Collections;
using System.Collections.Generic;

namespace LucasCollection
{
	class LucasCollection : IEnumerable<int>
	{
		readonly int n;

		public LucasCollection(int n) => this.n = n;
		public IEnumerator<int> GetEnumerator() => new LucasCollectionEnumerator(n);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private class LucasCollectionEnumerator : IEnumerator<int>
		{
			readonly int n;
			int position = -1;
			int l1 = 2;
			int l2 = 1;

			public LucasCollectionEnumerator(int n) => this.n = n;
			public void Dispose() { }
			public bool MoveNext()
			{
				if (position == n - 1)
					return false;
				position++;
				if (position > 1)
				{
					int l = l1 + l2;
					l1 = l2;
					l2 = l;
				}
				return true;
			}
			public void Reset() => position = -1;

			public int Current => position == 0 ? l1 : l2;
			object IEnumerator.Current => Current;
		}
	}
	class Program
	{
		static void Main()
		{
			int n;
			do
				Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
			foreach (int i in new LucasCollection(n))
				Console.Write($"{i} ");
		}
	}
}
