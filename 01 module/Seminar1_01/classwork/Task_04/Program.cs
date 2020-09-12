using System;

namespace Task_04
{
	class Program
	{
		static void Main(string[] args)
		{
			string result = "5 / 3 = " + 5 / 3;
			Console.WriteLine(result);
			result = "5.0 / 3.0 = " + 5.0 / 3.0;
			Console.WriteLine(result);
			result = 5 / 3 + " - это 5/3";
			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}
