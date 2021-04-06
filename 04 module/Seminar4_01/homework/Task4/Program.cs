using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Task4
{
    [Serializable]
    public class Multiple
    {
        int divisor;    // значение делителя
        readonly List<int> numbers;     // массив чисел, кратных divisor
        readonly string[] names = new string[] { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
        public override string ToString()
        {
            string mom = "Делитель: " + Divisor + " - " + Name + "\r\nКратные: ";
            foreach (int m in Numbers)
                mom += m + "  ";
            return mom;
        }
        public Multiple() { }
        public Multiple(int div, int[] ar)
        {
            Divisor = div;
            Numbers = new List<int>(ar);
        }

        public string Name => names[Divisor];
        public int Divisor
		{
            get => divisor;
            init
			{
                if (value <= 0 || value > 9)
                    throw new Exception("Неверно выбран делитель!");
                divisor = value;
            }
		}
        public List<int> Numbers
		{
            get => numbers;
            init => numbers = value.Where(x => x % Divisor == 0).ToList();
		}
    }
    class Program
	{
		static void Main()
		{
            Multiple row;           // ссылка на объект класса
            int size = 0;           // размер генеральной совокупности
            do
                Console.Write("Введите размер генеральной совокупности: ");
            while (!int.TryParse(Console.ReadLine(), out size) | size < 1);
            Random gen = new(5);
            int[] data = new int[size];    // генеральная совокупность
            for (int i = 0; i < size; i++)
            {
                data[i] = gen.Next(0, 100);
                Console.Write(data[i] + "  ");
            }
            Console.WriteLine();
            XmlSerializer formXml = new(typeof(Multiple));
			using FileStream byteStream = new("multiple.xml", FileMode.Create, FileAccess.ReadWrite);
			do
			{
				// цикл для создания и записи в файл объектов
				int div;
				do
				{    // цикл проверки делителя!
					do Console.Write("Введите делитель: ");
					while (!int.TryParse(Console.ReadLine(), out div));
					try
					{
						row = new Multiple(div, data);
						break;
					}
					catch (Exception)
					{
						Console.WriteLine("Нужен делитель от 1 до 9!");
						continue;
					}
				}
				while (true);
				// создан объект row, запишем его код в файл:
				formXml.Serialize(byteStream, row);
				byteStream.Flush();
				Console.WriteLine("\nДля чтения файла - клавиша ESC");
			} while (Console.ReadKey(true).Key != ConsoleKey.Escape);
			byteStream.Position = 0;
			while (true) // читать до конца файла 
				try
				{
					row = (Multiple)formXml.Deserialize(byteStream);
					Console.WriteLine(row.ToString());
				}
				catch
				{
					break;
				}
		}
    }
}
