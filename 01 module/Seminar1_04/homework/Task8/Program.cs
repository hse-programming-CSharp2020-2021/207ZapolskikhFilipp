using System;

namespace Task8
{
	class Program
	{
		static void Check(uint a, uint b, uint c)
		{
			if (a * a + b * b == c * c)
				Console.WriteLine($"A={a}, B={b}, C={c}");
		}
		static void Main(string[] args)
		{
			for (uint a = 1; a <= 20; a++)
				for (uint b = 1; b <= 20; b++)
					for (uint c = 1; c <= 20; c++)
						if (a != b && a != c && b != c)
							Check(a, b, c);
		}
	}
}
