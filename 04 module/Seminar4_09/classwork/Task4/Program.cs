using System;
using System.Text.RegularExpressions;

namespace Task4
{
	class Program
	{
		static void Main()
		{
			string s;
			Regex regex = new(@"[a-h][1-8]-[a-h][1-8]");
			while ((s = Console.ReadLine()) != null)
			{
				Match match = regex.Match(s);
				if (match.Success)
					Console.WriteLine(match.Value);
			}
		}
	}
}
