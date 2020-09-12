using System;

namespace Task04
{
	class Program
	{
		static void Main(string[] args)
		{
			double u, r, i, p;
			Console.WriteLine("Введите значение напряжения (В): ");
			bool bu = double.TryParse(Console.ReadLine(), out u);
			Console.WriteLine("Введите значение сопротивления (Ом): ");
			bool br = double.TryParse(Console.ReadLine(), out r);
			if (bu && br && r > 0.0 && u >= 0.0)
			{
				i = u / r;
				p = u * u / r;
				Console.WriteLine("Сила тока: " + i + " А");
				Console.WriteLine("Потребляемая мощность: " + p + " Вт");
			}
			else
			{
				Console.WriteLine("Неверные данные!");
			}
		}
	}
}
