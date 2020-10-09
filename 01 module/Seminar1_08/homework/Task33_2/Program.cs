using System;
using System.IO;
using System.Text;

namespace Task33_2
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
					|| array[i] < 0 || array[i] > 10000)
					return false;
			}
			return true;
		}
		static int Converter(int x)
		{
			int i = 0;
			while (x > 1)
			{
				x >>= 1;
				i++;
			}
			return 1 << i;
		}
		static void Main(string[] args)
		{
			int[] a;
			if (!ReadArray("input.txt", out a))
			{
				Console.WriteLine("Incorrect input");
				return;
			}
			int[] b = Array.ConvertAll(a, Converter);
			File.WriteAllText("output.txt", new StringBuilder().AppendJoin(' ', Array.ConvertAll(b, x => x.ToString())).ToString());
		}
	}
}
