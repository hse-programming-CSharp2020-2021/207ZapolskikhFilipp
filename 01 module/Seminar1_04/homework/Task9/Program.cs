using System;

namespace Task9
{
	class Program
	{
		static bool Input(ref int sum, ref int cnt)
		{
			while (true)
			{
				int i;
				Console.Write("Введите целое число или exit, чтобы выйти: ");
				string input = Console.ReadLine();
				if (input == "exit")
					return false;
				if (!int.TryParse(input, out i))
				{
					Console.WriteLine("Некорректный ввод");
					continue;
				}
				else
				{
					if (i < 0)
					{
						sum += i;
						cnt++;
						if (sum < -1000)
							return false;
					}
					return true;
				}
			}
		}
		static void Main(string[] args)
		{
			int sum = 0, cnt = 0;
			while (Input(ref sum, ref cnt)) ;
			Console.WriteLine($"Среднее арифметическое: {(double)sum / cnt}");
		}
	}
}
