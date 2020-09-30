using System;

namespace Task7
{
	class Program
	{
		static void Euclide(uint a, uint b, out uint nod, out uint nok)
		{
			uint oldA = a;
			uint oldB = b;
			while (a != b)
			{
				if (a > b)
					a -= b;
				else
					b -= a;
			}
			nod = a;
			nok = oldA * oldB / a;
		}
		static void Main(string[] args)
		{
			uint a, b, nod, nok;
			Console.Write("Введите A: ");
			if (!uint.TryParse(Console.ReadLine(), out a))
			{
				Console.WriteLine("Некорректный ввод");
				return;
			}
			Console.Write("Введите B: ");
			if (!uint.TryParse(Console.ReadLine(), out b))
			{
				Console.WriteLine("Некорректный ввод");
				return;
			}
			Euclide(a, b, out nod, out nok);
			Console.WriteLine($"НОД: {nod}");
			Console.WriteLine($"НОК: {nok}");
		}
	}
}
