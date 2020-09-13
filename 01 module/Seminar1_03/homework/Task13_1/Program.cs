using System;

namespace Task1
{
	class Program
	{
		public static uint Solve(out uint last)
		{
			uint res = 1;
			for (last = 1; res % 111 != 0; res += last)
				last++;
			return res;
		}
		static void Main(string[] args)
		{
			uint last, ans = Solve(out last);
			Console.WriteLine($"1+2+3+...+{last - 2}+{last - 1}+{last}={ans}");
		}
	}
}
