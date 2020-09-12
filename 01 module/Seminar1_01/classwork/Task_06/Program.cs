using System;

namespace Task_06
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("(5.0/3.0) = " + (5.0 / 3.0).ToString("F"));
			Console.WriteLine("(5.0/3.0) = " + (5.0 / 3.0).ToString("F4"));
			Console.WriteLine("(5.0/3.0) = " + (5.0 / 3.0).ToString("E"));
			Console.WriteLine("(5.0/3.0) = " + (5.0 / 3.0).ToString("E5"));
			Console.WriteLine("(5.0/3.0) = " + (5.0 / 3.0).ToString("G"));
			Console.WriteLine("(5.0/3.0) = " + (5.0 / 3.0).ToString("G3"));
			Console.WriteLine("(5.0/3e10) = " + (5.0 / 3e10).ToString("G3"));
		}
	}
}
