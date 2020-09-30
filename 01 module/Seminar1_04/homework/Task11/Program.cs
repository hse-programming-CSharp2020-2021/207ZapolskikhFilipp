using System;

namespace Task11
{
	class Program
	{
		static int Input(string str)
		{
			while (true)
			{
				int res;
				Console.Write(str);
				if (!int.TryParse(Console.ReadLine(), out res) || res >= 31)
					Console.WriteLine("Некорректный ввод");
				else
					return res;
			}
		}

		static void Main(string[] args)
		{
			int n = Input("Введите N: ");
			int m = Input("Введите M: ");
			Console.WriteLine($"Ответ: {(uint)(1 << n) + (1 << m)}");
		}
	}
}
