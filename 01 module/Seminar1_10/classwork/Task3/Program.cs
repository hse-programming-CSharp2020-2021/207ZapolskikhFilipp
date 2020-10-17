using System;
using System.Linq;

namespace Task3
{
	class Program
	{
		static int ReadNumber(string message, string errorMessage)
		{
			while (true)
			{
				Console.Write(message);
				int res;
				if (int.TryParse(Console.ReadLine(), out res) && res > 0 && res < 10000)
					return res;
				else
					Console.WriteLine(errorMessage);
			}
		}
		static int CountSum(int number)
		{
			int sum = 0;
			while (number > 0)
			{
				sum += number % 10;
				number /= 10;
			}
			return sum;
		}
		static int CountDigits(int number)
		{
			int cnt = 0;
			while (number > 0)
			{
				cnt++;
				number /= 10;
			}
			return cnt;
		}
		static void Main(string[] args)
		{
			while (true)
			{
				int a = ReadNumber("Enter A: ", "Incorrect input!");
				int b = ReadNumber("Enter B: ", "Incorrect input!");
				if (a > b)
				{
					Console.WriteLine("Incorrect input!");
					continue;
				}
				int[] array = new int[b - a + 1];
				for (int i = 0; i < array.Length; i++)
					array[i] = a + i;
				int[] array2 = Array.FindAll(array, x => CountSum(x) == CountDigits(x));
				if (array2.Length == 0)
					array2 = Array.FindAll(array, x => CountSum(x) == 2 * CountDigits(x));
				if (array2.Length > 0)
				{
					Console.Write("Array: ");
					Array.ForEach(array2, x => Console.Write($"{x} "));
					Console.WriteLine();
				}
				else
					Console.WriteLine("Fail!");

				Console.WriteLine("Press Esc to exit or another key to continue...");
				ConsoleKeyInfo key = Console.ReadKey();
				if (key.Key == ConsoleKey.Escape)
					break;
				Console.WriteLine();
			}
		}
	}
}
