using System;
using System.IO;

namespace _2
{
	class Program
	{
		static void PrintBin(uint n)
		{
			if (n == 0)
				return;
			PrintBin(n / 2);
			Console.Write(n % 2);
		}
		static void Main(string[] args)
		{
			string filename = "../../../../IntNumber.txt";
			if (!File.Exists(filename))
			{
				Console.WriteLine("File doesn't exist!");
				return;
			}
			byte[] array = File.ReadAllBytes(filename);
			uint number = (uint)(array[0] << 24) + (uint)(array[1] << 16) + (uint)(array[2] << 8) + (uint)array[3];
			Console.WriteLine($"{number}");
			PrintBin(number);
		}
	}
}
