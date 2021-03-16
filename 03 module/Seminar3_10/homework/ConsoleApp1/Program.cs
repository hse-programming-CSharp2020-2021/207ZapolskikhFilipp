using System;
using System.IO;
using System.Linq;
using ClassLibrary;

namespace ConsoleApp1
{
	class Program
	{
		static void Main()
		{
			int n;
			do
				Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 0);

			Street[] streetsArray = GetStreets(n);
			Array.ForEach(streetsArray, Console.WriteLine);
			try
			{
				File.WriteAllLines("out.txt", Array.ConvertAll(streetsArray, street => street.ToString()));
			}
			catch (Exception exception)
			{
				Console.WriteLine("Couldn't write out.txt: " + exception.Message);
			}
		}
		static Street[] GetStreets(int n)
		{
			Street[] streetsArray;
			try
			{
				streetsArray = File.ReadLines("data.txt").Where(line => !string.IsNullOrWhiteSpace(line)).Select(line =>
				{
					string[] array = line.Split();
					int[] houses = array.Skip(1).Select(int.Parse).ToArray();
					if (houses.Length == 0)
						throw new ArgumentException("Empty street");
					if (houses.Any(num => num < 1 || num > 100))
						throw new ArgumentException("Incorrect house number");
					return new Street() { Name = array[0], Houses = houses };
				}).ToArray().Take(n).ToArray();
			}
			catch (Exception exception)
			{
				Console.WriteLine("Incorrect input: " + exception.Message);
				Random rnd = new Random();
				streetsArray = new Street[n];
				for (int i = 0; i < n; i++)
				{
					char[] name = new char[5];
					int[] houses = new int[rnd.Next(2, 10)];
					for (int j = 0; j < 5; j++)
						name[j] = (char)('a' + rnd.Next(26));
					for (int j = 0; j < houses.Length; j++)
						houses[j] = rnd.Next(1, 101);
					name[0] = char.ToUpper(name[0]);
					streetsArray[i] = new Street() { Name = new string(name), Houses = houses };
				}
			}
			return streetsArray;
		}
	}
}
