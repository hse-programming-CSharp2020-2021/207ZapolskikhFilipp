using System;

namespace mark
{
	class Program
	{
		static void Main(string[] args)
		{
			int x = int.Parse(Console.ReadLine());
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
