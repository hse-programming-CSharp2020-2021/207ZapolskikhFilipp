using System;
using System.IO;

namespace _1
{
	class Program
	{
		static void Main(string[] args)
		{
			uint n;
			do Console.Write("Enter N: ");
			while (!uint.TryParse(Console.ReadLine(), out n));
			File.WriteAllBytes("../../../../IntNumber.txt", new byte[] { (byte)(n >> 24), (byte)(n >> 16), (byte)(n >> 8), (byte)n });
		}
	}
}
