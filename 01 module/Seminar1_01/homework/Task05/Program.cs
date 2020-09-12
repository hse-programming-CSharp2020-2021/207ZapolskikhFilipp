using System;

namespace Task05
{
	class Program
	{
		static void Main(string[] args)
		{
			double a, b;
			Console.WriteLine("Введите длину первого катета: ");
			bool ba = double.TryParse(Console.ReadLine(), out a);
			Console.WriteLine("Введите длину второго катета: ");
			bool bb = double.TryParse(Console.ReadLine(), out b);
			if (ba && bb && a > 0.0 && b > 0.0)
			{
				double c = Math.Sqrt(a * a + b * b);
				Console.WriteLine("Длина гипотенузы: " + c);
			}
			else
			{
				Console.WriteLine("Неверные данные!");
			}
		}
	}
}
