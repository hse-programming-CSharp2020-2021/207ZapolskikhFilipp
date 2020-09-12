using System;

namespace rand
{
	class Program
	{
		public static string RandomString()
		{
			Random rnd = new Random();
			int len = rnd.Next(3, 10);
			string res = "";
			for (int i = 0; i < len; i++)
				res += (char)rnd.Next('a', 'z' + 1);
			return res;
		}
		static void Main(string[] args)
		{
			for (int i = 0; i < 10; i++)
				Console.WriteLine(RandomString());
		}
	}
}
