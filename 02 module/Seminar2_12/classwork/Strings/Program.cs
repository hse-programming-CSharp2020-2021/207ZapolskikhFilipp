using System;
using System.Linq;
using System.Text;

namespace Strings
{
	class Program
	{
		static string Task1(string[] words) => new StringBuilder().AppendJoin(' ', words).ToString();
		static int Task2(string[] words) => words.Count(x => x.Length > 4);
		static int Task3(string[] words) => words.Count(x => "ауоыиэяюёе".Contains(char.ToLower(x[0])));
		static void Main(string[] args)
		{
			string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
			Console.WriteLine(Task1(words));
			Console.WriteLine($"Количество слов из более, чем 4 букв: {Task2(words)}");
			Console.WriteLine($"Количество слов, начинающихся с гласной буквы: {Task3(words)}");
		}
	}
}
