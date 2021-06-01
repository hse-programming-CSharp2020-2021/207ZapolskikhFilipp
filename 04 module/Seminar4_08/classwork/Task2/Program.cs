using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Task2
{
	class Program
	{
		private const int RUNS = 1_000;
		static readonly ConcurrentDictionary<int, int> dictionary = new();
		static void AddOrUpdate()
		{
			for (var i = 0; i < RUNS; ++i)
			{
				if (dictionary.TryAdd(i, i))
					Console.WriteLine($"{i} was added");
				else if (dictionary.TryUpdate(i, dictionary[i] + 1, dictionary[i]))
					Console.WriteLine($"{i} was updated to {dictionary[i]}");
			}
		}
		static void Main()
		{
			Task.WaitAll(
				Task.Run(() => AddOrUpdate()),
				Task.Run(() => AddOrUpdate()),
				Task.Run(() => AddOrUpdate()),
				Task.Run(() => AddOrUpdate()),
				Task.Run(() => AddOrUpdate()));
			Console.WriteLine($"Total number of elements: { dictionary.Count }");
		}
	}
}
