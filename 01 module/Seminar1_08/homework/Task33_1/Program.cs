using System;
using System.IO;
using System.Text;

namespace Task33_1
{
	class Program
	{
		static bool ReadArray(string filename, out int[] array)
		{
			array = null;
			if (!File.Exists(filename))
				return false;
			string[] values = File.ReadAllText(filename).Split(' ');
			array = new int[values.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if (!int.TryParse(values[i], out array[i])
					|| array[i] < -10 || array[i] > 10)
					return false;
			}
			return true;
		}
		static void Main(string[] args)
		{
			int[] a;
			if (!ReadArray("input.txt", out a))
			{
				Console.WriteLine("Incorrect input");
				return;
			}
			bool[] l = Array.ConvertAll<int, bool>(a, (x) => { return x >= 0; });
			File.WriteAllText("output.txt", new StringBuilder().AppendJoin(' ', Array.ConvertAll(l, x => x.ToString())).ToString());
		}
	}
}
