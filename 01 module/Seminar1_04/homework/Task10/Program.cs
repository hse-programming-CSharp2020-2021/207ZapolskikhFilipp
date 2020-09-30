using System;

namespace Task10
{
	class Program
	{
		static double a, b, c;
		static double Input(string str)
		{
			while (true)
			{
				double res;
				Console.Write(str);
				if (!double.TryParse(Console.ReadLine(), out res))
					Console.WriteLine("Некорректный ввод");
				else
					return res;
			}
		}
		static double F(double x)
		{
			return x < 1.2 ? a * x * x + b * x + c : (x == 1.2 ? a / x + Math.Sqrt(x * x + 1.0) : (a + b * x) / Math.Sqrt(x * x + 1.0));
		}
		static void Main(string[] args)
		{
			a = Input("Введите a: ");
			b = Input("Введите b: ");
			c = Input("Введите c: ");
			for (int i = 0; i <= 20; i++)
				Console.WriteLine($"X={1.0 + i / 20.0}, Y={F(1.0 + i / 20.0)}");
		}
	}
}
