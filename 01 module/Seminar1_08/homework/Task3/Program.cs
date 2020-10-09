using System;
using System.IO;
using System.Text;

namespace Task3
{
	class Program
	{
		static Random rand = new Random();
		const string fileName = "dialog.txt";
		static Encoding enc = Encoding.Unicode;
		const int linesCount = 6;
		static void Main()
		{
			CreateFile();
			ProcessFile();
		}
		// Читаем сформированный файл и обрабатываем предложения.
		private static void ProcessFile()
		{
			// Массив сообщений из переписки.
			string[] messages = File.ReadAllLines(fileName, enc);
			Console.WriteLine(Environment.NewLine + "Переписка после форматирования:");
			foreach (string item in messages)
			{
				int length = item.Length;
				if (item.EndsWith('.'))
					length--;
				// Выводим сообщения из переписки без точек на экран.
				Console.WriteLine(item.Substring(0, length));
			}
		}
		// Создаём файл на диске.
		private static void CreateFile()
		{
			// Создаём пустой файл.
			File.WriteAllText(fileName, string.Empty, enc);
			Console.WriteLine("Переписка до форматирования:");
			for (int i = 0; i < linesCount; i++)
			{
				string message = string.Empty;
				// Длина сообщения от 20 до 50 символов (51 - 50 включён в диапазон).
				int length = rand.Next(20, 51);
				// Посимвольное добавление букв в сообщение. "Ё" нет в диапазоне от А до Я!
				for (int j = 0; j < length; j++)
					message += (char)rand.Next('а', 'я');
				if (rand.Next(0, 2) == 1)
					message += ".";
				// Добавляем в сообщение точку и перенос на следующую строку.
				message += Environment.NewLine;
				// Добавляем строку в файл.
				File.AppendAllText(fileName, message, enc);
				Console.Write(message);
			}
		}
	}
}
