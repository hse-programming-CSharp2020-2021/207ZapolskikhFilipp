using System;
using System.Text;

namespace Task5
{
	class Program
	{
		static readonly string[] bin = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
		const string hex = "0123456789abcdef";
		static string ConvertHex2Bin1(string str) => string.Concat(Array.ConvertAll(str.ToCharArray(), x => bin[hex.IndexOf(char.ToLower(x))]));
		static string ConvertHex2Bin2(string str) => new StringBuilder().AppendJoin("", Array.ConvertAll(str.ToCharArray(), x => bin[hex.IndexOf(char.ToLower(x))])).ToString();
		static void Main(string[] args)
		{
			string[] test = { "5a1", "5a2", "5A3" };
			foreach (string s in test)
				Console.WriteLine($"{ConvertHex2Bin1(s)} {ConvertHex2Bin2(s)}");
		}
	}
}
