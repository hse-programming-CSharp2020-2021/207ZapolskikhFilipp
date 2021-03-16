using System;
using System.IO;

namespace Task3
{
	class Program
	{
		static void Main()
		{
			string path = @"..\..\..\input.txt";
			Random rnd = new Random();
			using (StreamWriter writer = new StreamWriter(path))
			{
				for (int i = 0; i < 100; i++)
					writer.WriteLine(rnd.NextDouble() * 900 + 100);
			}

			using (StreamReader reader = new StreamReader(path))
			{
				Console.SetIn(reader);
				double sum = 0;
				for (int i = 0; i < 100; i++)
					sum += double.Parse(Console.ReadLine());
				Console.WriteLine(sum / 100);
				Console.SetIn(new StreamReader(Console.OpenStandardInput()));
			}
		}
	}
}
