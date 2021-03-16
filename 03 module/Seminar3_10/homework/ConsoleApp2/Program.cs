using System;
using System.IO;
using System.Linq;
using ClassLibrary;

namespace ConsoleApp2
{
	class Program
	{
		static void Main()
		{
			try
			{
				Street[] magicStreets = GetStreets().Where(street => ~street % 2 == 1 && !street).ToArray();
				Array.ForEach(magicStreets, Console.WriteLine);
			}
			catch (Exception exception)
			{
				Console.WriteLine("Incorrect input: " + exception.Message);
			}
		}
		static Street[] GetStreets() => File.ReadLines(@"..\..\..\..\ConsoleApp1\bin\Debug\net5.0\out.txt").Select(line =>
			{
				string[] array = line.Split();
				int[] houses = array.Skip(1).Select(int.Parse).ToArray();
				return new Street() { Name = array[0], Houses = houses };
			}).ToArray();
	}
}
