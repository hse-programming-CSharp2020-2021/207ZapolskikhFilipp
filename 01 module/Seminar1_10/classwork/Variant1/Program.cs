using System;

namespace Variant1
{
	class Program
	{
		static bool ParseNumbers(string text, out int[] numbers)
		{
			string[] sNumbers = text.Split(' ');
			numbers = new int[sNumbers.Length];
			for (int i = 0; i < numbers.Length; i++)
			{
				if (!int.TryParse(sNumbers[i], out numbers[i]) || numbers[i] <= 0)
					return false;
			}
			return true;
		}
		static int[] Primes(int[] sequence)
		{
			return Array.FindAll(sequence, x =>
			{
				for (int i = 2; i <= Math.Sqrt(x); i++)
					if (x % i == 0)
						return false;
				return x != 1;
			});
		}
		static bool IsNonDecreasing(int[] sequence, out int min)
		{
			min = int.MaxValue;
			bool result = true;
			for (int i = 0; i < sequence.Length; i++)
			{
				min = Math.Min(min, sequence[i]);
				if (i != sequence.Length - 1 && sequence[i] > sequence[i + 1])
					result = false;
			}
			return result;
		}
		static void Main(string[] args)
		{
			while (true) {
				int n;
				int[] numbers;
				do Console.Write("Enter N: ");
				while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 10000);
				do Console.Write("Enter N numbers separated by spaces: ");
				while (!ParseNumbers(Console.ReadLine(), out numbers) || numbers.Length != n);

				int[] pArray = Primes(numbers);
				int min;
				Console.WriteLine($"Prime numbers count: {pArray.Length}");
				Console.Write($"Prime numbers:");
				Array.ForEach(pArray, x => Console.Write($" {x}"));
				Console.WriteLine();
				Console.WriteLine($"Sequence is non-decreasing: {IsNonDecreasing(pArray, out min)}");
				Console.WriteLine($"Sequence minimum: {min}");
				Console.WriteLine("Press Esc to exit or another key to continue...");
				ConsoleKeyInfo key = Console.ReadKey();
				if (key.Key == ConsoleKey.Escape)
					break;
				Console.WriteLine();
			}
		}
	}
}
