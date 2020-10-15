using System; // Для доступа к классу Console
using System.IO; // Для работы с файлами и директориями

namespace Task1
{
	class Program
	{
		static void Main()
		{
			// Блок try-catch при работе с файлами обязателен!
			try
			{
				DirectoryOverview(@"..\..\..\");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
			Console.WriteLine("Нажмите любую клавишу, чтобы выйти");
			Console.ReadKey();
		}
		private static void DirectoryOverview(string v)
		{
			Console.WriteLine($"Full path: {Path.GetFullPath(v)}\n" +
				$"Attributes: {File.GetAttributes(v)}\n" +
				$"Creation Time: {Directory.GetCreationTime(v)}\n" +
				$"Last write time: {Directory.GetLastWriteTime(v)}\n");
			foreach (string dir in Directory.GetDirectories(v))
				DirectoryOverview(dir);
		}
	}
}