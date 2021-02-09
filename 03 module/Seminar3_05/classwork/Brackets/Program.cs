using System;

namespace Brackets
{
	class Program
	{
		static bool Validate(string s)
		{
			int i = 0;
			foreach (char c in s)
			{
				i += c == '(' ? 1 : -1;
				if (i < 0)
					return false;
			}
			return i == 0;
		}
		static void Main() => Console.Write(Validate(Console.ReadLine()));
	}
}
