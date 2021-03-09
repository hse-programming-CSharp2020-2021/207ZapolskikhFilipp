using System;
using System.IO;

namespace Task3
{
	class Program
	{
		static void Main()
		{
			using FileStream fStream = File.OpenRead(@"../../../Program.cs");
			int i;
			while ((i = fStream.ReadByte()) != -1)
			{
				if (char.IsDigit((char)i))
					Console.Write((char)i);
			}
		}
	}
}
