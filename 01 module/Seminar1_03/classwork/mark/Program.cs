using System;

namespace mark
{
	class Program
	{
		static void Main(string[] args)
		{
			uint x;
			do
			{
				Console.Write("Enter a mark: ");
			} while (!uint.TryParse(Console.ReadLine(), out x) || x < 1 || x > 10);
			switch (x)
			{
				case 1:
				case 2:
				case 3:
					Console.WriteLine("Неудовлетворительно");
					break;
				case 4:
				case 5:
					Console.WriteLine("Удовлетворительно");
					break;
				case 6:
				case 7:
					Console.WriteLine("Хорошо");
					break;
				case 8:
				case 9:
				case 10:
					Console.WriteLine("Отлично");
					break;
			}
		}
	}
}
